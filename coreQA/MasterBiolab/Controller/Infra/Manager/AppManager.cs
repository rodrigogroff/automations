using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Master.Entity.Dto.Domain.Auth;
using Master.Entity.Dto.Infra.RegTime;
using Microsoft.Extensions.Caching.Memory;

namespace Master.Controller.Manager
{
    public interface IAppManager
    {
        #region - cache - 

        string RetrieveCache(IMemoryCache memoryCache, string tagCache);
        void SaveCache(IMemoryCache memoryCache, string cacheValue, string tagCache, int minutes = 60);
        void RemoveCache(IMemoryCache memoryCache, string tagCache);
        void RemoveAllCache(IMemoryCache memoryCache, string startTag, List<string> tagLstCacheContains);
        void AddNewRequest(bool cached);
        long GetRequests(bool cached);
        void AddNewRequestTime(long milis);
        long GetRequestsMaxTime();
        long GetRequestsMinTime();
        long GetRequestsAvgTime();
        List<string> GetLastRequestsPerMInute();
        string GetStartDate();

        #endregion

        void RegTime(string id, string label);
        bool AddNode(DtoRegisterInformation reg);
        bool CheckNode(DtoRegisterInformation reg);
        bool CheckWaveDone();
        void NodeWorkDone(DtoRegisterInformation reg);
        int TotalNodes();
        bool StartWave(int totalNodes);
        void CleanUp();
        void Start();
        void Stop();
        bool CanStart();
        List<DtoRegTimeInfo> RegStatus();
        DtoRegTimeReport RegReport();
        DtoRegTimeReportFinal RegReportFinal();
    }

    public class AppManager : IAppManager
    {
        #region - cache - 

        public List<string> myTags = new List<string>();
        private long totalTime = 0;
        private long minTime = 999999999;
        private long maxTime = 0;
        private long requests = 0;
        private long requestsCached = 0;
        private int collision_status = 0;
        private Hashtable hshReqHourMin = new Hashtable();
        private List<string> lstReqHourMin = new List<string>();
        private DateTime dtStart = DateTime.Now;

        public string RetrieveCache(IMemoryCache memoryCache, string tagCache)
        {
            if (memoryCache.TryGetValue(tagCache, out string data))
            {
                return data;
            }

            return null;
        }

        public void SaveCache(IMemoryCache memoryCache, string cacheValue, string tagCache, int minutes = 60)
        {
            var lockWasTaken = false;
            try
            {
                lockWasTaken = Interlocked.CompareExchange(ref collision_status, 1, 0) == 0;
                if (lockWasTaken)
                {
                    memoryCache.Set(tagCache, cacheValue, DateTimeOffset.Now.AddMinutes(minutes));

                    if (!myTags.Contains(tagCache))
                    {
                        myTags.Add(tagCache);
                    }
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Volatile.Write(ref collision_status, 0);
                }
            }
        }

        public void RemoveCache(IMemoryCache memoryCache, string tagCache)
        {
            var lockWasTaken = false;
            try
            {
                lockWasTaken = Interlocked.CompareExchange(ref collision_status, 1, 0) == 0;
                if (lockWasTaken)
                {
                    memoryCache.Remove(tagCache);
                    myTags.Remove(tagCache);
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Volatile.Write(ref collision_status, 0);
                }
            }
        }

        public void RemoveAllCache(IMemoryCache memoryCache, string startTag, List<string> tagLstCacheContains)
        {
            var lockWasTaken = false;
            try
            {
                lockWasTaken = Interlocked.CompareExchange(ref collision_status, 1, 0) == 0;
                if (lockWasTaken)
                {
                    foreach (var currentCacheTag in tagLstCacheContains)
                    {
                        foreach (var tagCache in myTags.Where(y => y.Contains(startTag + currentCacheTag)).ToList())
                        {
                            memoryCache.Remove(tagCache);
                            myTags.Remove(tagCache);
                        }
                    }
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Volatile.Write(ref collision_status, 0);
                }
            }
        }

        public void AddNewRequest(bool cached)
        {
            var lockWasTaken = false;
            try
            {
                lockWasTaken = Interlocked.CompareExchange(ref collision_status, 1, 0) == 0;
                if (lockWasTaken)
                {
                    if (!cached)
                    {
                        requests++;
                    }
                    else
                    {
                        requestsCached++;
                    }

                    var tag_req_hour_min = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");
                    if (hshReqHourMin[tag_req_hour_min] == null)
                    {
                        hshReqHourMin[tag_req_hour_min] = 0;
                        lstReqHourMin.Add(tag_req_hour_min);
                    }

                    int counter = (int)hshReqHourMin[tag_req_hour_min];
                    counter++;
                    hshReqHourMin[tag_req_hour_min] = counter;
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Volatile.Write(ref collision_status, 0);
                }
            }
        }

        public long GetRequests(bool cached)
        {
            return !cached ? requests : requestsCached;
        }

        public void AddNewRequestTime(long milis)
        {
            var lockWasTaken = false;
            try
            {
                lockWasTaken = Interlocked.CompareExchange(ref collision_status, 1, 0) == 0;
                if (lockWasTaken)
                {
                    totalTime += milis;
                    if (milis < minTime)
                    {
                        minTime = milis;
                    }

                    if (milis > maxTime)
                    {
                        maxTime = milis;
                    }
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Volatile.Write(ref collision_status, 0);
                }
            }
        }

        public long GetRequestsMaxTime()
        {
            return maxTime;
        }

        public long GetRequestsMinTime()
        {
            return minTime;
        }

        public long GetRequestsAvgTime()
        {
            return totalTime / requests;
        }

        public List<string> GetLastRequestsPerMInute()
        {
            if (lstReqHourMin.Count > 2)
            {
                lstReqHourMin.RemoveRange(0, lstReqHourMin.Count - 2);
            }

            var ret = new List<string>();
            foreach (var item in lstReqHourMin.OrderByDescending(y => y))
            {
                int counter = (int)hshReqHourMin[item];
                ret.Add(item + " -> " + counter + " requests/minute");
            }

            return ret;
        }

        public string GetStartDate()
        {
            return dtStart.ToString("dd/MM/yyyy HH:mm");
        }

        #endregion

        bool bStartProcesses = false;

        List<DtoRegisterInformation> nodes = new List<DtoRegisterInformation>();
        List<RegTimeData> regTimes = new List<RegTimeData>();
        List<DtoRegTimeReport> regReports = new List<DtoRegTimeReport>();

        bool IAppManager.AddNode(DtoRegisterInformation reg)
        {
            if (!nodes.Any(y => y.id == reg.id))
            {
                nodes.Add(reg);
                return true;
            }

            return false;
        }

        bool IAppManager.CheckNode(DtoRegisterInformation reg)
        {
            var n = nodes.FirstOrDefault( y=> y.id == reg.id);

            if (n != null)
            {
                return n.IsWorkRequired == true;
            }

            return false;
        }

        void IAppManager.NodeWorkDone(DtoRegisterInformation reg)
        {
            var n = nodes.FirstOrDefault(y => y.id == reg.id);

            if (n != null)
            {
                n.IsWorkRequired = false;
                n.IsFinished = true;
            }
        }

        bool IAppManager.StartWave(int totalNodes)
        {
            for (int i = 0; i < nodes.Count; ++i)
            {
                nodes[i].IsWorkRequired = false;
                nodes[i].IsFinished = true;
            }

            for (int i = 0; i < totalNodes; ++i)
            {
                nodes[i].IsWorkRequired = true;
                nodes[i].IsFinished = false;
            }

            return true;
        }

        bool IAppManager.CheckWaveDone()
        {
            bool ready = true;

            for (int i = 0; i < nodes.Count; ++i)
            {
                if (nodes[i].IsFinished != true)
                {
                    ready = false;
                }
            }

            return ready;
        }

        int IAppManager.TotalNodes()
        {
            return nodes.Count();
        }

        void IAppManager.RegTime(string id, string label)
        {
            var obj = regTimes.FirstOrDefault(y => y.id == id && y.label == label);

            if (obj == null)
            {
                regTimes.Add(new RegTimeData
                {
                    dtStart = DateTime.Now,
                    dtEnd = null,
                    id = id,
                    label = label
                });
            }
            else
            {
                obj.dtEnd = DateTime.Now;
            }
        }

        public List<DtoRegTimeInfo> RegStatus()
        {
            var ret = new List<DtoRegTimeInfo>();

            foreach (var item in regTimes.Where(y => y.dtEnd != null))
            {
                var r = new DtoRegTimeInfo
                {
                    id = item.id,
                    label = item.label,
                    dtStart = item.dtStart,
                    dtEnd = Convert.ToDateTime(item.dtEnd),
                    milis = 0
                };

                if (item.dtEnd != null)
                {
                    r.milis = Convert.ToInt32(
                                Convert.ToDateTime(item.dtEnd).
                                    Subtract(item.dtStart).
                                        TotalMilliseconds);

                    ret.Add(r);
                }
            }

            return ret;
        }

        public DtoRegTimeReport RegReport()
        {
            var _regTimes = regTimes.Where(y => y.dtEnd != null).ToList();

            var ret = new DtoRegTimeReport
            {
                ids = _regTimes.Select(y => y.id).Distinct().ToList(),
                labels = _regTimes.Select(y => y.label).Distinct().ToList()
            };

            ret.VUs = ret.ids.Count();

            ret.data = new List<DtoRegTimeInfo>();

            foreach (var item in _regTimes)
            {
                var r = new DtoRegTimeInfo
                {
                    id = item.id,
                    label = item.label,
                    dtStart = item.dtStart,
                    dtEnd = Convert.ToDateTime(item.dtEnd),
                    milis = Convert.ToInt32(
                                Convert.ToDateTime(item.dtEnd).
                                    Subtract(item.dtStart).
                                        TotalMilliseconds)
                };

                ret.data.Add(r);
            }

            ret.stats = new List<DtoRegTimeInfoStat>();

            foreach (var currentLabel in ret.labels)
            {
                var results = ret.data.
                                Where(y => y.label == currentLabel).
                                    Select(y => y.milis).ToList();

                var r = new DtoRegTimeInfoStat
                {
                    label = currentLabel,
                    min = results.Min(y => y),
                    max = results.Max(y => y),
                    avg = results.Sum(y => y) / ret.VUs,
                };

                ret.stats.Add(r);
            }

            regReports.Add(ret);
            regTimes.Clear();

            return ret;
        }

        public DtoRegTimeReportFinal RegReportFinal()
        {
            var ret = new DtoRegTimeReportFinal();

            ret.VUs = new List<int>();

            foreach (var item in regReports)
            {
                ret.VUs.Add(item.VUs);
            }

            ret.reports = regReports;

            return ret;
        }

        public void Start()
        {
            bStartProcesses = true;
        }

        public void Stop()
        {
            bStartProcesses = false;
        }

        public bool CanStart()
        {
            return bStartProcesses;
        }

        public void CleanUp()
        {
            regTimes = new List<RegTimeData>();
            regReports = new List<DtoRegTimeReport>();
        }
    }
}
