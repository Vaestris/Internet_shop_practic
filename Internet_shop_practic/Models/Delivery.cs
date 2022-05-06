using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    /// <summary>
    /// Доставка
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// Id доставки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заказ отгружен: да/нет
        /// </summary>
        public bool Shipment { get; set; }

        /// <summary>
        /// Заказ передан курьеру: да/нет
        /// </summary>
        public bool Issued { get; set; }

        /// <summary>
        /// Заказ доставлен: да/нет
        /// </summary>
        public bool Delivered { get; set; }
        
        /// <summary>
        /// время доставки
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Внешний ключ Заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// навигационные свойство 
        /// </summary>
        public Order Order { get; set; }

    }
}
