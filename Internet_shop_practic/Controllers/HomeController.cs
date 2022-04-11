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

       public ActionResult GetOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetOrder(Customer customer, Order order)
        {

            ProgramContext programContext = new ProgramContext();
           
            Jsonfile Jsonfile = new Jsonfile();
            Jsonfile.Jsonwriter(order, customer, programContext);
            return RedirectToAction("OrderDone");
        }
        public ActionResult OrderDone()
        {
            return View();
        }
    }

    
}
