using CoffeShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShopWeb.Controllers
{
    public class HomeController : Controller
    {

        public ObservableCollection<FoodCategory> categoryList { get; set; }

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
            //if (Session["usernameLogin"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}

            categoryList = new ObservableCollection<FoodCategory>(dataProvider.Ins.DB.FoodCategories);
            return View(categoryList);
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