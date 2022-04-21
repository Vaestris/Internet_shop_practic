using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    //заказ
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }

        //внещний ключ
        public int CustomerId { get; set; }
        //внещний ключ
        public int ProductId { get; set; }


        //навигационные свойство 
        public Customer Customer { get; set; }
        //навигационные свойство 
        public Product Product { get; set; }


        public Delivery Delivery { get; set; }

    }
}
