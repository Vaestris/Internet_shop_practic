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

        public void isjsonexists(order order, customer customer, int idc, int ido)
        {
           
            if (File.Exists("orderjsonfile.json"))
            {
                filereading(order, customer, idc, ido);
            }

            else
            {               
               
            }
            if (File.Exists("customerjsonfile.json"))
            {
                filereading(order, customer, idc,  ido);
            }

            else
            {
                               
            }


        }
        public void filereading(order order, customer customer, int idc, int ido)
        {
            order neworder = new order();
            neworder = order;
            customer newcustomer = new customer();
            newcustomer = customer;
            List<customer> listc = new List<customer>();
            List<order> listo = new List<order>();

            string json = File.ReadAllText("customerjsonfile.json");
            listc = JsonSerializer.Deserialize<List<customer>>(json);
            
            json = File.ReadAllText("orderjsonfile.json");
            listo = JsonSerializer.Deserialize<List<order>>(json);

            neworder = listo.Find(x => x.id == ido);
            newcustomer = listc.Find(x => x.id == idc);
           
            Checking(neworder, customer);






        }
        public void Checking(order order, customer customer)
        {

        }
        


    }

}
