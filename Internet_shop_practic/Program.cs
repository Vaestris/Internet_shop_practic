using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Security.Authentication;

namespace Internet_shop_practic
{
    /// <summary>
    /// �������� �����, �� �������� ����������� ���������
    /// </summary>
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// ����� ������������ ��� ����������
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
                        listenopt.UseHttps("C:/Users/���� ���������/Documents/ServerCert.pfx", "123");
                    }
                    );
                }).UseStartup<Startup>() ;
               
            });
    }      
}
