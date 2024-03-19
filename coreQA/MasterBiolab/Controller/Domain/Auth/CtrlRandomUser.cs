using Master.Controller.Infra;
using Master.Controller.Manager;
using Master.Entity;
using Master.Entity.Dto.Domain.Auth;
using Master.Service.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Controller.Domain.Auth
{
    public class CtrlRandomUser : MasterController
    {
        public CtrlRandomUser(IOptions<LocalNetwork> network, IMemoryCache cache, IAppManager appManager) : base(network, cache, appManager) { }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/randomUser")]
        public async Task<ActionResult> RandomUser()
        {
            var max = 5000;
            var id = GenerateRandomNumber(5000);
            var tag = string.Empty;

            var IsUsed = true;

            for (int t = 0; t < max; t++)
            {
                tag = "Random_" + id + "_";

                IsUsed = IsProcessCached<DtoRandomUser>(tag);

                if (!IsUsed)
                    break;

                id = GenerateRandomNumber(max);
            }

            if (IsUsed)
            {
                AppManager.RemoveAllCache(MemoryCache, string.Empty, new List<string> { "Random_" });

                tag = "Random_" + id + "_";

                IsProcessCached<DtoRandomUser>(tag);
            }

            var srv = RegisterService<SrvRandomUser>();

            if (!srv.Exec(id, Network))
            {
                return BadRequest(srv.Error);
            }

            return Ok(SaveProcessCache(tag, srv.OutDto));
        }
    }
}
