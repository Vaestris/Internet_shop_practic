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
   
    public class consolewrite
    {
        static void consolerite(string[] args)
        {
            
            customer newcustomer = new customer();
            Console.WriteLine("Введите Имя: ");
            newcustomer.fname = Console.ReadLine();
            Console.WriteLine("Введите Фамилию: ");
            newcustomer.lname = Console.ReadLine();
            Console.WriteLine("Введите Номер телефона: ");
            newcustomer.phone_number = Console.ReadLine();
            Console.WriteLine("Введите Компанию: ");
            newcustomer.company = Console.ReadLine();
            order neworder = new order();
            Console.WriteLine("Введите Id продкута (системное): ");
            neworder.productId = Console.Read();
            jsonfile jsonfile = new jsonfile();
            jsonfile.isjsonexists(neworder, newcustomer);


        }

    }
    public class jsonfile
    {

        public void isjsonexists(order order, customer customer)
        {
            if (!File.Exists("orderjsonfile.json"))
            {
                File.Create("orderjsonfile.json");
                bool exists = false;
                jsonwriter(order, customer, exists);
            }

            else
            {
                bool exists = true;
                jsonwriter(order, customer, exists);
            }
            if (!File.Exists("customerjsonfile.json"))
            {
                File.Create("customerjsonfile.json");
                bool exists = false;
                jsonwriter(order, customer, exists);
            }

            else
            {
                bool exists = true;
                jsonwriter(order, customer, exists);
            }


        }
        public void jsonwriter(order order, customer customer, bool exists)
        {

            order neworder = new order();
            neworder = order;
            customer newcustomer = new customer();
            newcustomer = customer;
            List<customer> listc = new List<customer>();
            List<order> listo = new List<order>();




            string json = File.ReadAllText("customerjsonfile.json");
            if (exists == true)
            {
                listc = JsonSerializer.Deserialize<List<customer>>(json);
            }

            listc.Add(newcustomer);
            json = JsonSerializer.Serialize(listc);
            File.WriteAllText("customerjsonfile.json", json);

            json = File.ReadAllText("orderjsonfile.json");
            if (exists == true)
            {
                listo = JsonSerializer.Deserialize<List<order>>(json);
            }

            listo.Add(neworder);
            json = JsonSerializer.Serialize(listo);
            File.WriteAllText("orderjsonfile.json", json);
        }


    }

}
