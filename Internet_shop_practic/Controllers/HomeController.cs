using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Internet_shop_practic
{
    public class HomeController : Controller
    {
        private readonly IGetProducts _ProductsInterface;
        
        public HomeController(IGetProducts iproducts)
        {
            _ProductsInterface = iproducts;
        }

        // Выводит страницу для ввода заказа и данных заказчика.
       public ActionResult GetOrder()
        {
            Order order = new Order() {Address= "adress" };
            return View(order);
        }

         
    
        public ActionResult OrderDone()
        {
            return View();
        }
    }

    
}
