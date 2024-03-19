using Master.Controller.Helper;
using Master.Controller.Manager;
using Master.Entity;
using Master.Entity.Dto.Infra;
using Master.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Master.Controller.Infra
{
    [Authorize]
    [ApiController]
    public partial class MasterController : ControllerBase
    {
        public IMemoryCache MemoryCache; // microsoft builtin component
        public IAppManager AppManager; // scoped custom manager
        public IHttpContextAccessor HttpContextAccessor;
        public LocalNetwork Network; // main settings
        public ServiceManager ServiceManager; // memory and dispose manager
        public SrvBase BaseService; // current controller service

        private HelperAesDecrypt AesDecryptHelper = null; // used sparsely
        private HelperJwtComposer JwtComposerHelper = null; // used sparcely

        public DateTime timeStamp;
        public object CachedObject;

        public MasterController(IOptions<LocalNetwork> network, IMemoryCache memoryCache, IAppManager appManager, IHttpContextAccessor httpContextAccessor = null)
        {
            this.Network = network.Value;
            this.MemoryCache = memoryCache;
            this.AppManager = appManager;
            ServiceManager = new ServiceManager(this);
            this.HttpContextAccessor = httpContextAccessor;
        }

        [NonAction]
        public void FinishService()
        {
            BaseService.Dispose();
            AesDecryptHelper = null;
            JwtComposerHelper = null;
            CachedObject = null;
            AppManager.AddNewRequestTime(GetCurrentTimeDiff());
        }

        [NonAction]
        public int GenerateRandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(1, max + 1) - 1;
        }

        long GetCurrentTimeDiff()
        {
            var _diff = DateTime.Now - timeStamp;
            return (long)_diff.TotalMilliseconds;
        }

        [NonAction]
        public T RegisterService<T>()
            where T : new()
        {
            var baseService = new T();
            this.BaseService = baseService as SrvBase;
            this.BaseService.Network = Network;
            HttpContext.Response.RegisterForDispose(ServiceManager);
            AppManager.AddNewRequest(cached: false);
            timeStamp = DateTime.Now;
            return baseService;
        }

        [NonAction]
        public bool IsProcessCached<T>(string tag)
        {
            var retCache = AppManager.RetrieveCache(MemoryCache, tag);
            if (retCache != null)
            {
                var srvCache = new SrvBase
                {
                    CachedObject = JsonConvert.DeserializeObject<T>(retCache),
                };
                BaseService = srvCache;
                HttpContext.Response.RegisterForDispose(ServiceManager);
                AppManager.AddNewRequest(cached: true);
                CachedObject = srvCache.CachedObject;
                return true;
            }

            return false;
        }

        [NonAction]
        public object SaveProcessCache(string tag, object obj)
        {
            AppManager.SaveCache(MemoryCache, JsonConvert.SerializeObject(obj), tag);
            return obj;
        }

        [NonAction]
        public DtoAuthenticatedUser CurrentUser()
        {
            var handler = new JwtSecurityTokenHandler();
            var authHeader = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            if (string.IsNullOrEmpty(authHeader))
            {
                return null;
            }

            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var claims = tokenS.Claims;
            return System.Text.Json.JsonSerializer.Deserialize<DtoAuthenticatedUser>(
                claims.FirstOrDefault(claim => claim.Type == "user")?.Value);
        }

        public HelperAesDecrypt AesDecrypt
        {
            get
            {
                if (AesDecryptHelper == null)
                {
                    AesDecryptHelper = new HelperAesDecrypt();
                    return AesDecryptHelper;
                }
                else
                {
                    return AesDecryptHelper;
                }
            }
        }

        public HelperJwtComposer JwtComposer
        {
            get
            {
                if (this.JwtComposerHelper == null)
                {
                    JwtComposerHelper = new HelperJwtComposer();
                    return JwtComposerHelper;
                }
                else
                {
                    return JwtComposerHelper;
                }
            }
        }
    }
}
