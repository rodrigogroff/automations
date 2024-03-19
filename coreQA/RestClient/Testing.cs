using RestSharp;
using System;

namespace IntegrationClient
{
    internal class Testing
    {
        static void Main(string[] args)
        {
            try
            {
                new IntegrationTesting().MainSelector();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }

    public partial class IntegrationTesting
    {
        public static string baseUri = @"http://localhost:5000";

        string localDatabase = @"User ID=postgres;Password=gustavo123;Host=localhost;Port=5432;Database=PowerAdmin";
        string token = "";
        string currentContents = "";

        public void MainSelector()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("######################################################");
                Console.WriteLine("Select domain for integration testing");
                Console.WriteLine("######################################################");
                Console.WriteLine("[au] Auth");
                Console.WriteLine("...............");
                Console.WriteLine("[!] ALL");

                var domain = Console.ReadLine();

                switch (domain)
                {
                    case "au": Domain_Auth_All(); break;

                    case "!":
                        Domain_Auth_All();
                        break;
                }
            }
        }

        public void ProcessOutput(string contents)
        {
            currentContents = contents;
        }

        void LoginAuto()
        {
            #region - code - 

            var dest = baseUri + @"/api/v1/login";
            var client = new RestClient(dest);
            var request = new RestRequest();

            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
                       
            request.AddBody(new
            {
                email = "teste@teste.com.br",
                password = "142536"
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return;

            token = response.Content.ToString().Split('\"')[3];

            #endregion
        }
    }
}
