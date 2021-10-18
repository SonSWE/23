using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShopWeb.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Paid()
        {
            return View();
        }
    }
}