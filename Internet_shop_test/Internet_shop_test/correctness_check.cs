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

namespace Internet_shop_test
{
    public class check
    {

        public void isjsonexists(Order order, Customer customer, int idc, int ido)
        {
           
            if (File.Exists("orderjsonfile.json"))
            {
                filereading(order, customer, idc, ido);
            }

           
            if (File.Exists("customerjsonfile.json"))
            {
                filereading(order, customer, idc,  ido);
            }

            

        }
        public void filereading(Order order, Customer customer, int idc, int ido)
        {
            Order neworder = new Order();
            neworder = order;
            Customer newcustomer = new Customer();
            newcustomer = customer;
            List<Customer> listc = new List<Customer>();
            List<Order> listo = new List<Order>();

            string json = File.ReadAllText("customerjsonfile.json");
            listc = JsonSerializer.Deserialize<List<Customer>>(json);
            
            json = File.ReadAllText("orderjsonfile.json");
            listo = JsonSerializer.Deserialize<List<Order>>(json);

            neworder = listo.Find(x => x.id == ido);
            newcustomer = listc.Find(x => x.id == idc);
           
            Checking(neworder, customer);






        }
        public void Checking(Order order, Customer customer)
        {

        }
        


    }

}
