using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Internet_shop_practic
{
    /// <summary>
    /// Основной класс, из которого запускается программа
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
           
            using (DBmodel db = new DBmodel())
            {
                 db.SaveChanges();
            }
            CreateHostBuilder(args).Build().Run();

        }
        /// <summary>
        /// Класс развертывает веб приложение
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
