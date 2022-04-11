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
using Internet_shop_practic.Models;

namespace Internet_shop_practic
{
    public class Check
    {
        //Проверяет файл и заполнен ли он и получает из него данные о новом заказе или(и) заказчике      
        public void Filereading()
        {
            Order neworder = new Order();            
            Customer newcustomer = new Customer();
            
            List<Customer> listc = new List<Customer>();
            List<Order> listo = new List<Order>();
            string json = "";
            if (File.Exists("../Internet_shop_practic/jsonfiles/customerjsonfile.json"))
            {
                json = File.ReadAllText("../Internet_shop_practic/jsonfiles/customerjsonfile.json");                                                   
                listc = JsonSerializer.Deserialize<List<Customer>>(json);
                newcustomer = listc.Find(x => x.Id == listc.Max(p => p.Id));
            }

            if (File.Exists("../Internet_shop_practic/jsonfiles/orderjsonfile.json"))
            {
                json = File.ReadAllText("../Internet_shop_practic/jsonfiles/orderjsonfile.json");
                listo = JsonSerializer.Deserialize<List<Order>>(json);
                neworder = listo.Find(x => x.Id == listo.Max(p => p.Id));
            }
            if (neworder != null || newcustomer != null)
            {
                Checking(neworder, newcustomer);
            }

        }
        public void Checking(Order order, Customer customer)
        {
            if(Convert.ToByte(customer.Fname) > 64 || customer.Fname == "")
            {

            }
        }
        


    }

}
