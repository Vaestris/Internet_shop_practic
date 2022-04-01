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
            ProgramContext programContext = new ProgramContext();
            Order neworder = new Order();

            Customer newcustomer = new Customer();

            

            using (ProgramContext db = new ProgramContext())
            {
                 db.customers.Add(new Customer {phone_number = "1", fname = "name", lname = "Lname", company = "company" });
                 //db.orders.Add(new Order { id_order = 1, product_number = 1 });
                //db.products.Add(new Product { product_number = "1", existence = 1, name = "shtuka" });
                 //db.deliveries.Add(new Delivery { order_number = "1", shipment = true, issued = true, delivered  = true, time = "";});
                db.SaveChanges();
            }
            CreateHostBuilder(args).Build().Run();

            jsonfile jsonfile = new jsonfile();
            jsonfile.isjsonexists(neworder, newcustomer, programContext);


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
