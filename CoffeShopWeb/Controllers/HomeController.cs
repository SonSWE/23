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

        

        #region Menu
        public ActionResult MainMenu()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        #region method
        #endregion
        #endregion

        #region Table
        public ActionResult Table()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        #region method
        #endregion
        #endregion

        #region Category
        public ActionResult FoodCategories()
        {
            //if (Session["usernameLogin"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}

            return View();
        }
        #region method

        [HttpGet]
        public JsonResult GetCategoryList()
        {
            try
            {
                ObservableCollection<FoodCategory> categoryList = new ObservableCollection<FoodCategory>(dataProvider.Ins.DB.FoodCategories.Where(x=>x.IsDel == false));
                return Json(new { code = 200, CategoryList = categoryList, msg = "Lấy danh sách danh mục thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách danh mục thât bại: "+ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddCategory(string name, string note)
        {
            try
            {
                var category = new FoodCategory() { Id = Guid.NewGuid().ToString(), Name = name, Note = note, DateAdd = DateTime.Now, IsDel = false };
                dataProvider.Ins.DB.FoodCategories.Add(category);
                dataProvider.Ins.DB.SaveChanges();

                return Json(new { code = 200, msg = "Thêm danh mục thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm danh mục mới thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ViewInfor(string id)
        {
            try
            {
                var category = dataProvider.Ins.DB.FoodCategories.Where(x => x.Id == id).SingleOrDefault();

                return Json(new { code = 200, infor = category, msg = "Sửa danh mục thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Sửa danh mục mới thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EditCategory(string id, string name, string note)
        {
            try
            {
                var category = dataProvider.Ins.DB.FoodCategories.Where(x => x.Id == id).SingleOrDefault();
                category.Name = name;
                category.Note = note;
                dataProvider.Ins.DB.SaveChanges();

                return Json(new { code = 200, msg = "Sửa danh mục thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Sửa danh mục mới thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteCategory(string id)
        {
            try
            {
                var category = dataProvider.Ins.DB.FoodCategories.Where(x => x.Id == id).SingleOrDefault();
                category.IsDel = true;
                dataProvider.Ins.DB.SaveChanges();

                return Json(new { code = 200, msg = "Xóa danh mục thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Xóa danh mục mới thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #endregion

        #region Food
        public ActionResult Food()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        #region method
        #endregion
        #endregion

        #region Statistic
        public ActionResult Statistic()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        #region method
        #endregion
        #endregion

        #region Account
        public ActionResult Account()
        {
            if (Session["usernameLogin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        #region method
        #endregion
        #endregion
    }
}