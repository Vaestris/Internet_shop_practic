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

using Internet_shop_practic.interfaces;
using Internet_shop_practic.Repository;
using Microsoft.EntityFrameworkCore;
using Internet_shop_practic.Models;

namespace Internet_shop_practic
{
    
   
    // Класс, осуществляющий работу по записи новых заказов и заказчиков в json файл для дальнейшей проверки корректности записанных данных.
    public class Jsonfile 
    {

        // Запись новых заказчкиков и заказов в jsone файлы для проверки их корректности перед добавлением их в бд.
        public void Jsonwriter(Order order, Customer customer, DBmodel programContext)
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

            int maxidc = customers.ToList().Max(p => p.Id);
            //int maxido = orders.ToList().Max(p => p.id);

            if (!File.Exists("../Internet_shop_practic/jsonfiles/customerjsonfile.json"))
            {
                File.Create("../Internet_shop_practic/jsonfiles/customerjsonfile.json");
            }            
            string json = File.ReadAllText("../Internet_shop_practic/jsonfiles/customerjsonfile.json");
            if (json != "")
            {
                listc = JsonSerializer.Deserialize<List<Customer>>(json);
                if (listc.Max(p => p.Id) > maxidc)
                    maxidc = listc.Max(p => p.Id);
            }

            newcustomer.Id = maxidc+1;
            listc.Add(newcustomer);            
            json = JsonSerializer.Serialize(listc);
            if (json != null)
                File.WriteAllText("../Internet_shop_practic/jsonfiles/customerjsonfile.json", json);
            

            if (!File.Exists("../Internet_shop_practic/jsonfiles/orderjsonfile.json"))
            {
                File.Create("../Internet_shop_practic/jsonfiles/orderjsonfile.json");
            }
            json = File.ReadAllText("../Internet_shop_practic/jsonfiles/orderjsonfile.json");
            if (json != "")
            {
                listo = JsonSerializer.Deserialize<List<Order>>(json);
                //if (listo.Max(p => p.id) > maxido)
                //    maxido = listo.Max(p => p.id);
            }

            // neworder.id = maxido;

            listo.Add(neworder);
            json = JsonSerializer.Serialize(listo);
            if(json !=null)
                File.WriteAllText("../Internet_shop_practic/jsonfiles/orderjsonfile.json", json);
            
        }


    }

}
