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
        /// Принимает данные заказа и вызывает проверку, возвращая овтет: в случае неправильных данных отсылает список оишбок.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOrder(Order order)
        {
            string[] errormessage;

            Check Check = new Check();
            Check.Checking(order, out errormessage);
            if (Array.TrueForAll(errormessage, x => x == null))
            {
                DBmodel programContext = new DBmodel();
                using (DBmodel db = new DBmodel())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                };
                return Ok();
            }
            else
            {

                return new JsonResult (errormessage);
            }
            
        }      
    }
}
