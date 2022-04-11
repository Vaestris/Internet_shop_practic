using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    //доставка
    public class Delivery
    {
        public int Id { get; set; }
        public int Order_number { get; set; }
        public bool Shipment { get; set; }
        public bool Issued { get; set; }
        public bool Delivered { get; set; }
        public DateTime Time { get; set; }
        //внещний ключ
        public int OrderId { get; set; }
        //навигационные свойство 
        public Order Order { get; set; }

    }
}
