using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Адресс доставки
        /// </summary>
       public string Address { get; set; }
/*
        /// <summary>
        /// Итоговая цена
        /// </summary>
        public int TotalPrice { get; set; }

        /// <summary>
        /// Время и дата оплаты
        /// </summary>
        public DateTime PaymentTime { get; set; }
*/
        /// <summary>
        /// Внешний ключ Заказчика
        /// </summary>
        public int CustomerId { get; set; }
        
        /// <summary>
        /// Внешний ключ товара
        /// </summary>
        public int ProductId { get; set; } 

        /// <summary>
        /// навигационные свойство 
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// навигационные свойство 
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// навигационные свойство 
        /// </summary>
        public Delivery Delivery { get; set; }

    }
}
