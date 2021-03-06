using System;
using Internet_shop_practic.Models;

namespace Internet_shop_practic
{
    /// <summary>
    /// Класс, проверяющий правильность введенных данных заказа
    /// </summary>
    public class Check
    {  
        /// <summary>
        /// Проверка введенных данных заказа
        /// </summary>
        /// <param name="order"></param>
        /// <param name="errormessage">Массив сообщений ошибок</param>
        /// <returns></returns>
        public Order Checking(Order order, out string[] errormessage)           
        {
            errormessage = new string[5];           
            if (String.IsNullOrEmpty(order.Address))
            {
                errormessage[1] = "Введите адресс";
            }
            else 
            {
                if (order.Address.Length > 50)
                {
                    errormessage[1] = "Адрес слишком длинный";
                }
                else
                {
                    errormessage[1] = null;
                }
                
            }
            
            return order;
            
        }
        
       


    }

}
