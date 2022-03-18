using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Internet_shop_test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new ProgramContext())
            {
                // db.Customers.Add(new customer {phone_number = 1, fname = "name", lname = "Lname", company = "company" });
                // db.Orders.Add(new order {phone_number = 1, id_order = 1, product_number = 1 });
                //db.Products.Add(new product { product_number = 1, existence = 1, name = "shtuka" });
                // db.deliveries.Add(new delivery { order_number = 1, shipment = true, issued = true, delivered  = true, time = "";});
                //db.SaveChanges();
            }
            CreateHostBuilder(args).Build().Run();

            

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
