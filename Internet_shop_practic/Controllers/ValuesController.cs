using Microsoft.AspNetCore.Mvc;
using System;
using Internet_shop_practic.Models;

namespace Internet_shop_practic.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Принимает данные заказа и вызывает проверку
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetOrder(Order order)
        {
            string[] errormessage;
            DBmodel programContext = new DBmodel();

            Check Check = new Check();
            Check.Checking(order, out errormessage);
            if (Array.TrueForAll(errormessage, x => x == null))
            {
                using (DBmodel db = new DBmodel())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                };
            }
            else
            {

               return errormessage;
            }
            return order;
        }      
    }
}
