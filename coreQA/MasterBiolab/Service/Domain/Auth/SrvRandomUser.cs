using Master.Entity;
using Master.Entity.Dto.Domain.Auth;
using Master.Entity.Dto.Infra;
using Master.Service.Base;
using System;

namespace Master.Service.Domain.Auth
{
    public class SrvRandomUser : SrvBase
    {
        public DtoRandomUser OutDto { get; set; }

        public bool Exec(int id, LocalNetwork network)
        {
            try
            {
                OutDto = new DtoRandomUser
                {
                    id = id.ToString()
                };

                return true;
            }
            catch (Exception ex)
            {
                Error = new DtoServiceError
                {
                    message = GENERIC_FAIL,
                    debugInfo = ex.ToString()
                };

                return false;
            }
        }
    }
}
