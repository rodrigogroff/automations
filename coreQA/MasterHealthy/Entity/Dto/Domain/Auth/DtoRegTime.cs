using System;
using System.Collections.Generic;

namespace Master.Entity.Dto.Domain.Auth
{
    public class DtoRegTime
    {
        public string id { get; set; }

        public string label { get; set; }
    }

    public class DtoRegTimeInfo
    {
        public string id { get; set; }

        public string label { get; set; }

        public int milis { get; set; }

        public DateTime dtStart { get; set; }

        public DateTime dtEnd { get; set; }
    }

    public class DtoRegTimeInfoStat
    {
        public string label { get; set; }

        public double avg { get; set; }

        public int min { get; set; }

        public int max { get; set; }
    }

    public class DtoRegTimeReport
    {
        public List<DtoRegTimeInfo> data { get; set; }

        public int VUs { get; set; }

        public List<string> ids { get; set; }

        public List<string> labels { get; set; }

        public List<DtoRegTimeInfoStat> stats { get; set; }
    }

    public class DtoRegTimeReportFinal
    {
        public List<int> VUs { get; set; }

        public List<DtoRegTimeReport> reports { get; set; }
    }
}
