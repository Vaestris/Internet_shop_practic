using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

using Internet_shop_test.interfaces;
using Internet_shop_test.Repository;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop_test
{
    
    public class consolewrite
    {
        
        static void consolerite(string[] args)
        {
            
            Customer newcustomer = new Customer();
            Console.WriteLine("Введите Имя: ");
            newcustomer.fname = Console.ReadLine();
            Console.WriteLine("Введите Фамилию: ");
            newcustomer.lname = Console.ReadLine();
            Console.WriteLine("Введите Номер телефона: ");
            newcustomer.phone_number = Console.ReadLine();
            Console.WriteLine("Введите Компанию: ");
            newcustomer.company = Console.ReadLine();
            Order neworder = new Order();
            Console.WriteLine("Введите Id продкута (системное): ");
            neworder.productId = Console.Read();
            jsonfile jsonfile = new jsonfile();
           // jsonfile.isjsonexists(neworder, newcustomer);


        }

    }
    public class jsonfile 
    {
        
        public void isjsonexists(Order order, Customer customer, ProgramContext programContext)
        {
            bool orderexists = false;
            bool customerexists = false;
            if (!File.Exists("orderjsonfile.json"))
            {
                File.Create("orderjsonfile.json");
                 orderexists = false;
               
            }

            else
            {
                orderexists = true;
               
            }
            if (!File.Exists("customerjsonfile.json"))
            {
                File.Create("customerjsonfile.json");
                 customerexists = false;
                
            }

            else
            {
                 customerexists = true;
                
            }
            jsonwriter(order, customer, orderexists, customerexists, programContext);

        }
        public void jsonwriter(Order order, Customer customer, bool orderexists, bool customerexists, ProgramContext programContext)
        {
            

            Order neworder = new Order();
            neworder = order;
            Customer newcustomer = new Customer();
            newcustomer = customer;
            List<Customer> listc = new List<Customer>();
            List<Order> listo = new List<Order>();
            List<Customer> Allcustomers = new List<Customer>();
                
            GetCustomers getCustomers = new GetCustomers(programContext);
            IEnumerable<Customer> customers = getCustomers.AllCustomers;

            GetOrders getOrders = new GetOrders(programContext);
            IEnumerable<Order> orders = getOrders.AllOrders;

            int maxidc = customers.ToList().Max(p => p.id);
            //int maxido = orders.ToList().Max(p => p.id);


            string json = File.ReadAllText("customerjsonfile.json");
            if (orderexists == true && json != "")
            {
                listc = JsonSerializer.Deserialize<List<Customer>>(json);
                if (listc.Max(p => p.id) > maxidc)
                    maxidc = listc.Max(p => p.id);
            }
            

            newcustomer.id = maxidc;

            listc.Add(newcustomer);            
            json = JsonSerializer.Serialize(listc);
            File.WriteAllText("customerjsonfile.json", json);

            json = File.ReadAllText("orderjsonfile.json");
            if (customerexists == true && json != "")
            {
                listo = JsonSerializer.Deserialize<List<Order>>(json);
                //if (listo.Max(p => p.id) > maxido)
                //    maxido = listo.Max(p => p.id);
            }

           

            // neworder.id = maxido;

            listo.Add(neworder);
            json = JsonSerializer.Serialize(listo);
            File.WriteAllText("orderjsonfile.json", json);
            
        }


    }

}
