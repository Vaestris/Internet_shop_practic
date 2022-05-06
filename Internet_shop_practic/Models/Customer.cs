using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Id заказчика
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// телефонный номер заказчика
        /// </summary>
        public string Phone_number { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///Фамилия
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        ///Название компании 
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// навигационное свойство
        /// </summary>
        public List<Order> Orders { get; set; }

    }
}
