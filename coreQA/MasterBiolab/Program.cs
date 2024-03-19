using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Master
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    webBuilder.ConfigureLogging((context, logging) =>
                    {
                        logging.ClearProviders();
                    });

#if TESTING
                    webBuilder.UseKestrel((hostingContext, options) =>
                    {
                        options.Listen(IPAddress.Loopback, 5000);
                    });         
#endif

#if RELEASE
                    webBuilder.UseKestrel((hostingContext, options) =>
                    {
                        //openssl x509 -text -in poweradmin.com.br.pem -out poweradmin.com.br.crt
                        //openssl pkcs12 -export -out certificate.pfx -inkey poweradmin.com.br.key -in poweradmin.com.br.crt
                        options.Listen(IPAddress.Parse("216.238.111.117"), 5000, listenOptions => {
                                listenOptions.UseHttps("certificate.pfx", "password");
                            });
                        
                    });
                    webBuilder.ConfigureLogging((context, logging) =>
                    {
                        logging.ClearProviders();
                    });
#endif
                });
    }
}
