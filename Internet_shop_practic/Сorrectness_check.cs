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
        public Order Checking(Order order, out string[] errormessage)           
        {
            errormessage = new string[5];
            if (Convert.ToByte(order.Address) > 64 )
            {
                errormessage[1] = "Адресс слишком длинный";
            }
            if (String.IsNullOrEmpty(order.Address))
            {
                errormessage[1] = "Введите адресс";
            }
            else 
            {
                errormessage[1] = null;
            }
            
            return order;
            
        }
        
       


    }

}
