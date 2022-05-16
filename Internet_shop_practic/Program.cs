using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
            Host.CreateDefaultBuilder(args)/*.ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
            });*/
            .ConfigureWebHostDefaults(webBuilder =>
            {
                 webBuilder.UseStartup<Startup>();
             });
    }
}
