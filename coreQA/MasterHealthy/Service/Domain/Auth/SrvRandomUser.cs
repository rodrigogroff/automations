using Master.Controller.Domain.Auth;
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

        public bool Exec(int id, int id_produto, HealthyData data, LocalNetwork network)
        {
            try
            {
                OutDto = new DtoRandomUser
                {
                    id = id.ToString(),
                    VirtualCardNumber = data.beneficiarios[id].VirtualCardNumber,
                    SocialNumber = data.beneficiarios[id].SocialNumber,
                    Cartao = data.Cartao,
                    CPF = data.CPF,
                    Produto = data.produtos[id_produto].EAN
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
