using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internet_shop_practic.Models;

namespace Internet_shop_practic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public Order GetOrder(Order order)
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
