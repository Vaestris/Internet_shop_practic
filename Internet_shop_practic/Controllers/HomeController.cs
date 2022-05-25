using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Internet_shop_practic
{
    public class HomeController : Controller
    {
        private readonly IGetProducts _ProductsInterface;

        public HomeController(IGetProducts iproducts)
        {
            _ProductsInterface = iproducts;
        }
        public ViewResult Index()
        {
            string test = "Hello world";

            return View(test);
        }
        //[Route("api/[controller]/[action]")]
        public ViewResult ProductList()
        {
            var p_roducts = _ProductsInterface.AllProducts;
            return View(p_roducts);
        }
        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";
            return View("ActionName");
        }
        public ActionResult PIndex()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

       /// <summary>
       /// Выводит страницу для ввода заказа
       /// </summary>
       /// <returns></returns>
        public ActionResult GetOrder()
        {

            Order order = new Order() { Address = "adress" };
            return View(order);
        }

        /// <summary>
        /// получает введенный заказ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetOrder(Order order)
        {

            string[] errormessage;
            DBmodel programContext = new DBmodel();

            Check Check = new Check();
            Check.Checking(order, out errormessage);
            if (Array.TrueForAll(errormessage, x => x == null))
            {
                return RedirectToAction("OrderDone");
            }
            else
            {

                ViewBag.errormessage = errormessage;
                return View(order);
            }
        }
        /// <summary>
        /// Выводит странницу, сообщающую, что заказ успешно введен
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderDone()
        {
            return View();
        }
        /// <summary>
        /// Выводит странциу ввода клиента
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCustomer()
        {

           
            return View();
        }

        /// <summary>
        /// Получает введеные данные клиента
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCustomer(Customer customer)
        {

        
         return RedirectToAction("CustomerGeted");
            

            
        }
        /// <summary>
        /// Выводит страницу, сообщаюшую, что данные успешно введены
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerGeted()
        {
            return View();
        }
    }

}
