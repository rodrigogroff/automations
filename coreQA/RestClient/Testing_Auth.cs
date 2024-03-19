using Master.Controller.Helper;
using Master.Service.Base;
using RestSharp;
using System;
using System.Net;

namespace IntegrationClient
{
    public partial class IntegrationTesting
    {
        void Domain_Auth_All()
        {
            Domain_Auth_Login((int)HttpStatusCode.BadRequest, "no_go1", "", "");
            Domain_Auth_Login((int)HttpStatusCode.BadRequest, "no_go2", "x", "");
            Domain_Auth_Login((int)HttpStatusCode.BadRequest, "no_go3", "", "x");

            string baseEmail = "testador.teste@teste.com.br";

            {
                #region - setup - 
                var myBase = new SrvBase();

                myBase.GetConnection(new Master.Entity.LocalNetwork { database = this.localDatabase });

                var id_company = myBase.rpCompany.InsertCompany(new Database.Company
                {
                    stName = "",
                    dtExpires = DateTime.Now,
                    dtJoin = DateTime.Now,
                });

                var id_user = myBase.rpUser.InsertUser(new Database.User
                {
                    fkCompany = id_company,
                    stName = "x",
                    stEmail = baseEmail,
                    stPassword = "123456",
                    bActive = true,
                    bAdmin = true,
                    bManager = true,
                });
                #endregion

                var testEmail = new HelperAesDecrypt().EncryptStringAES(baseEmail);
                var testPassword = new HelperAesDecrypt().EncryptStringAES("123456");

                Domain_Auth_Login((int)HttpStatusCode.OK, "registered_match", testEmail, testPassword);

                myBase.rpUser.DeleteUser(id_user);
                myBase.rpCompany.DeleteCompany(id_company);
                myBase.Dispose();
            }

            {
                #region - setup -

                var myBase = new SrvBase();
                                
                myBase.GetConnection(new Master.Entity.LocalNetwork { database = this.localDatabase });

                var id_company = myBase.rpCompany.InsertCompany(new Database.Company
                {
                    stName = "",
                    dtExpires = DateTime.Now,
                    dtJoin = DateTime.Now,
                });

                var id_user = myBase.rpUser.InsertUser(new Database.User
                {
                    fkCompany = id_company,
                    stName = "x",
                    stEmail = "x@x.com",
                    stPassword = "123456",
                    bActive = false, /// xxxxxxxxxxxxxxx
                    bAdmin = true,
                    bManager = true,
                });

                #endregion

                var testEmail = new HelperAesDecrypt().EncryptStringAES(baseEmail);
                var testPassword = new HelperAesDecrypt().EncryptStringAES("123456");

                Domain_Auth_Login((int)HttpStatusCode.BadRequest, "registered_not_active", testEmail, testPassword);

                myBase.rpUser.DeleteUser(id_user);
                myBase.rpCompany.DeleteCompany(id_company);

                myBase.Dispose();
            }

            {
                #region - setup - 

                var myBase = new SrvBase();

                myBase.GetConnection(new Master.Entity.LocalNetwork { database = this.localDatabase });

                var id_company = myBase.rpCompany.InsertCompany(new Database.Company
                {
                    stName = "",
                    dtExpires = DateTime.Now,
                    dtJoin = DateTime.Now,
                });

                var id_user = myBase.rpUser.InsertUser(new Database.User
                {
                    fkCompany = id_company,
                    stName = "x",
                    stEmail = baseEmail,
                    stPassword = "5555555",
                    bActive = false, /// xxxxxxxxxxxxxxx
                    bAdmin = true,
                    bManager = true,
                });

                #endregion

                var testEmail = new HelperAesDecrypt().EncryptStringAES(baseEmail);
                var testPassword = new HelperAesDecrypt().EncryptStringAES("123456");

                Domain_Auth_Login((int)HttpStatusCode.BadRequest, "registered_wrong_pass", testEmail, testPassword);

                myBase.rpUser.DeleteUser(id_user);
                myBase.rpCompany.DeleteCompany(id_company);

                myBase.Dispose();
            }

            {
                #region - setup - 

                var myBase = new SrvBase();

                myBase.GetConnection(new Master.Entity.LocalNetwork { database = this.localDatabase });

                var id_company = myBase.rpCompany.InsertCompany(new Database.Company
                {
                    stName = "",
                    dtExpires = DateTime.Now,
                    dtJoin = DateTime.Now,
                });

                var id_user = myBase.rpUser.InsertUser(new Database.User
                {
                    fkCompany = id_company,
                    stName = "x",
                    stEmail = "x@x.com.br", // no match
                    stPassword = "5555555",
                    bActive = true, 
                    bAdmin = true,
                    bManager = true,
                });

                #endregion

                var testEmail = new HelperAesDecrypt().EncryptStringAES(baseEmail);
                var testPassword = new HelperAesDecrypt().EncryptStringAES("123456");

                Domain_Auth_Login((int)HttpStatusCode.BadRequest, "registered_wrong_user", testEmail, testPassword);

                myBase.rpUser.DeleteUser(id_user);
                myBase.rpCompany.DeleteCompany(id_company);

                myBase.Dispose();
            }
        }

        void Domain_Auth_Login( int expectedResult, string typeTest, string email, string password)
        {
            #region - code - 

            var dest = baseUri + @"/api/portal/authenticate";

            var client = new RestClient(dest);
            var request = new RestRequest();

            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
            request.AddBody(new { email, password });

            var response = client.Execute(request);

            if ((int)response.StatusCode == expectedResult)
                Console.WriteLine("Domain_Auth_Login " + typeTest + " [OK]");
            else
            {
                Console.WriteLine("Domain_Auth_Login " + typeTest + " [FAIL]");
                Console.WriteLine(response.Content.ToString());
            }

            #endregion
        }
    }
}
