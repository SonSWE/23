using CoffeShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CoffeShopWeb.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["usernameLogin"] != null)
            {
                return RedirectToAction("MainMenu", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string passEncode = MD5Hash(Base64Encode(password));

            int count = dataProvider.Ins.DB.Accounts.Where(x => x.Username == username && x.Password == passEncode).Count();

            if (count >= 1)
            {
                string nameOfAccount = dataProvider.Ins.DB.Accounts.Where(x => x.Username == username).SingleOrDefault().Name;
                Session["usernameLogin"] = nameOfAccount;
                return RedirectToAction("MainMenu", "Home");
            }
            return View();
        }

        public static string Base64Encode(string plainText)
        {
            if (plainText == null)
                return "x";

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);

        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}