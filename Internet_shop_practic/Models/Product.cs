using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    //товар
    public class Product
    {
        public int Id { get; set; }
        public int Product_number { get; set; }
        public int Existence { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }

    }
}
