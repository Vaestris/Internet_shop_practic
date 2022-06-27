using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product
    {       
        /// <summary>
        /// id товара
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Existence { get; set; }
        
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена 
        /// </summary>
        public int Price { get; set; }
        
        /// <summary>
        /// Сколько ед товара забронировано и не может учитываться в качестве доступного
        /// </summary>
        public int Booked { get; set; }

        public List<Order> Orders { get; set; }

    }
}
