using Master.Entity.Dto.Domain.Auth;
using Master.Entity.Dto.Infra;
using Master.Service.Base;
using System;
using System.Collections.Generic;

namespace Master.Service.Domain.Auth
{
    public class SrvRegister : SrvBase
    {
        public bool Exec(DtoRegisterInformation dto)
        {
            try
            {
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
