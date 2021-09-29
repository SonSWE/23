using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShopWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MainMenu()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public ActionResult Table()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult FoodCategories()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        public ActionResult Food()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        public ActionResult Statistic()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        public ActionResult Account()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}