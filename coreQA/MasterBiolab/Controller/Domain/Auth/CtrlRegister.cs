using Master.Controller.Infra;
using Master.Controller.Manager;
using Master.Entity;
using Master.Entity.Dto.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Master.Controller.Domain.Auth
{
    public class CtrlRegister : MasterController
    {
        public CtrlRegister(IOptions<LocalNetwork> network, IMemoryCache cache, IAppManager appManager) : base(network, cache, appManager) { }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/registerNode")]
        public async Task<ActionResult> RegisterNode([FromBody] DtoRegisterInformation registerDto)
        {
            if (!AppManager.AddNode(registerDto))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/nodes")]
        public async Task<ActionResult> Nodes()
        {
            return Ok(AppManager.TotalNodes());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/sinc")]
        public async Task<ActionResult> Sinc()
        {
            if (DateTime.Now.Second % 2 == 0)
            {
                return Ok();
            }
            else
                return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/wait")]
        public async Task<ActionResult> Wait([FromBody] DtoRegisterInformation dto)
        {
            var workRequirec = AppManager.CheckNode(dto);

            return Ok(workRequirec == true ? "W" : string.Empty);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/workDone")]
        public async Task<ActionResult> WorkDone([FromBody] DtoRegisterInformation dto)
        {
            AppManager.NodeWorkDone(dto);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/startWave")]
        public async Task<ActionResult> startWave([FromBody] DtoStartWave dto)
        {
            if (AppManager.StartWave(dto.NodesTotal))
                return Ok();
            else
                return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/checkWave")]
        public async Task<ActionResult> checkWave()
        {
            if (AppManager.CheckWaveDone())
                return Ok();
            else
                return BadRequest();
        }
    }
}
