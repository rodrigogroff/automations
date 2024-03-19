using Master.Controller.Infra;
using Master.Controller.Manager;
using Master.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Master.Controller.Domain.CompanyUnit
{
    [AllowAnonymous]
    public class CtrlStats_Get : MasterController
    {
        public CtrlStats_Get(IOptions<LocalNetwork> network, IMemoryCache cache, IAppManager appManager) : base(network, cache, appManager) { }

        [HttpGet]
        [Route("api/portal/_stats")]
        public async Task<ActionResult> Get()
        {
            var r = this.AppManager.GetRequests(cached: false);
            var c = this.AppManager.GetRequests(cached: true);

            return this.Ok(new
            {
                startDate = this.AppManager.GetStartDate(),
                memory = ((double)(Process.GetCurrentProcess().PrivateMemorySize64 / 2048) / 1024).ToString("N3") + " Mb",
                _memory = (int)(Process.GetCurrentProcess().PrivateMemorySize64 / 2048) / 1024,
                requests = r,
                requestsCached = c,
                cachePct = ((c * 100) / (r + c)) + "%",
                maxTime = this.AppManager.GetRequestsMaxTime(),
                minTime = this.AppManager.GetRequestsMinTime(),
                avgTime = this.AppManager.GetRequestsAvgTime(),
                RequestPerMinute = this.AppManager.GetLastRequestsPerMInute(),
            });
        }
    }
}
