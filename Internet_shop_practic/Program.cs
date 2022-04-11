using Internet_shop_practic.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Internet_shop_practic
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            using (ProgramContext db = new ProgramContext())
            {
                 //db.Customers.Add(new Customer {Phone_number = "1", Fname = "name", Lname = "Lname", Company = "company" });
                 //db.orders.Add(new Order { id_order = 1, product_number = 1 });
                //db.products.Add(new Product { product_number = "1", existence = 1, name = "shtuka" });
                 //db.deliveries.Add(new Delivery { order_number = "1", shipment = true, issued = true, delivered  = true, time = "";});
                db.SaveChanges();
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
