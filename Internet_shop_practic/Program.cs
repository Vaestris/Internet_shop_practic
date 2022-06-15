using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Security.Authentication;


namespace Internet_shop_practic
{
    /// <summary>
    /// Основной класс, из которого запускается программа
    /// </summary>
    public class Program
    {
        private static string certificat;
        private static string certificat_password;
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json").Build();
            certificat = config.GetSection("Kestrel:Certificates:Default:Path").Value;
            certificat_password = config.GetSection("Kestrel:Certificates:Default:Password").Value;
            
            CreateHostBuilder(args).Build().Run();
            
        }

        /// <summary>
        /// Развертывавает веб приложение
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(serverOptions =>                
                {
                    serverOptions.ConfigureHttpsDefaults(co =>
                    {
                        co.SslProtocols = SslProtocols.Tls12;

                    });
                    serverOptions.Listen(IPAddress.Parse("0.0.0.0"), 5001, listenopt =>
                    {                       
                        listenopt.UseHttps(certificat, certificat_password);
                    }
                    );
                }).UseStartup<Startup>() ;
               
            });
    }      
}
