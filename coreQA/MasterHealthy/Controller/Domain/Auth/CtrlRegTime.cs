using Master.Controller.Infra;
using Master.Controller.Manager;
using Master.Entity;
using Master.Entity.Dto.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Controller.Domain.Auth
{
    public class CtrlRegTime : MasterController
    {
        public CtrlRegTime(IOptions<LocalNetwork> network, IMemoryCache cache, IAppManager appManager) : base(network, cache, appManager) { }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/regId")]
        public async Task<ActionResult> RegId()
        {
            return Ok(Guid.NewGuid());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/regCleanup")]
        public async Task<ActionResult> RegCleanup()
        {
            AppManager.CleanUp();

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/regStart")]
        public async Task<ActionResult> RegStart()
        {
            AppManager.Start();

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/regStop")]
        public async Task<ActionResult> RegStop()
        {
            AppManager.Stop();

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/regTime")]
        public async Task<ActionResult> RegTime(DtoRegTime input)
        {
            AppManager.RegTime(input.id, input.label);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/RegStatus")]
        public async Task<ActionResult> RegStatus()
        {
            return Ok(AppManager.RegStatus());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/RegReport")]
        public async Task<ActionResult> RegReport()
        {
            return Ok(AppManager.RegReport());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/RegReportFinal")]
        public async Task<ActionResult> RegReportFinal()
        {
            return Ok(AppManager.RegReportFinal());
        }
    }
}
