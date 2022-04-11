using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    //заказчик
    public class Customer
    {
        public int Id { get; set; }
        public string Phone_number { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Company { get; set; }

        public List<Order> Orders { get; set; }

    }
}
