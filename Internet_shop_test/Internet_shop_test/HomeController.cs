using Internet_shop_test.interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_test
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
    }

    
}
