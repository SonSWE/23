using CoffeShopWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Runtime.CompilerServices;
using System.ComponentModel;

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
            //if (Session["usernameLogin"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}

            return View();
        }

        #region method
        //[HttpGet]
        //public JsonResult GetTableList()
        //{
        //    try
        //    {
        //        ObservableCollection<Table> tableList = new ObservableCollection<Table>(dataProvider.Ins.DB.Tables.Where(x => x.IsDel == false));
        //        return Json(new { code = 200, tableList = tableList, msg = "Lấy danh sách bàn thành công" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { code = 500, msg = "Lấy danh sách bàn thât bại: " + ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public JsonResult AddTable(string name, string status)
        //{
        //    try
        //    {
        //        var table = new Table() { Id = Guid.NewGuid().ToString(), Name = name, Status = status, IsDel = false };
        //        dataProvider.Ins.DB.Tables.Add(table);
        //        dataProvider.Ins.DB.SaveChanges();

        //        return Json(new { code = 200, msg = "Thêm bàn thành công!" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { code = 500, msg = "Thêm bàn thất bại : " + ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}


        //[HttpPost]
        //public JsonResult EditTable(string id, string name, string status)
        //{
        //    try
        //    {
        //        var table = dataProvider.Ins.DB.Tables.Where(x => x.Id == id).SingleOrDefault();
        //        table.Name = name;
        //        table.Status = status;
        //        dataProvider.Ins.DB.SaveChanges();

        //        return Json(new { code = 200, msg = "Sửa bàn thành công!" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { code = 500, msg = "Sửa bàn thất bại : " + ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public JsonResult DeleteTable(string id)
        //{
        //    try
        //    {
        //        var table = dataProvider.Ins.DB.Tables.Where(x => x.Id == id).SingleOrDefault();
        //        table.IsDel = true;
        //        dataProvider.Ins.DB.SaveChanges();

        //        return Json(new { code = 200, msg = "Xóa bàn thành công!" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { code = 500, msg = "Xóa bàn thất bại : " + ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
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
                ObservableCollection<FoodCategory> categoryList = new ObservableCollection<FoodCategory>(dataProvider.Ins.DB.FoodCategories.Where(x => x.IsDel == false));

                var list = JsonConvert.SerializeObject(categoryList, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                return Json(new { code = 200, CategoryList = list, msg = "Lấy danh sách danh mục thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách danh mục thất bại: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult SearchCategory(string nameCategory)
        {
            try
            {
                ObservableCollection<FoodCategory> categoryList;
                if(nameCategory == "" || nameCategory == null)
                {
                    categoryList = new ObservableCollection<FoodCategory>(dataProvider.Ins.DB.FoodCategories.Where(x => x.IsDel == false));
                } 
                else
                {
                    categoryList = new ObservableCollection<FoodCategory>(dataProvider.Ins.DB.FoodCategories.Where(x => x.IsDel == false && x.Name.Contains(nameCategory)));
                }

                var list = JsonConvert.SerializeObject(categoryList, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                return Json(new { code = 200, CategoryList = list, msg = "Tìm danh mục thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { code = 500, msg = "Tìm danh mục thất bại: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddCategory(string name, string note)
        {
            try
            {
                var category = new FoodCategory() { Id = Guid.NewGuid().ToString(), Name = name, Note = note, NameUserAdd = (string)Session["usernameLogin"], DateAdd = DateTime.Now, IsDel = false };
                dataProvider.Ins.DB.FoodCategories.Add(category);
                dataProvider.Ins.DB.SaveChanges();

                return Json(new { code = 200, msg = "Thêm danh mục thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm danh mục mới thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetInforCategory(string id)
        {
            try
            {
                var category = dataProvider.Ins.DB.FoodCategories.Where(x => x.Id == id).SingleOrDefault();

                var item = JsonConvert.SerializeObject(category, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                return Json(new { code = 200, Category = item, msg = "Lấy thông tin thành công!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
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
                category.NameUserChange = (string)Session["usernameLogin"];
                category.DateChange = DateTime.Now;

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
            //if (Session["usernameLogin"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}

            return View();
        }

        #region method

        

        [HttpGet]
        public JsonResult GetFoodList()
        {
            try
            {
                ObservableCollection<Food> foodList;
                foodList = new ObservableCollection<Food>(dataProvider.Ins.DB.Foods.Where(x => x.IsDel == false));

                var list = JsonConvert.SerializeObject(foodList, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                return Json(new { code = 200, foodList = list, msg = "Lấy danh sách món thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách món thât bại: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult SearchFood(string nameSearch, string idCategory)
        {
            try
            {
                ObservableCollection<Food> foodList;
                
                if (nameSearch == null || nameSearch == "")
                {
                    if (idCategory== "123987")
                        foodList = new ObservableCollection<Food>(dataProvider.Ins.DB.Foods.Where(x => x.IsDel == false));
                    else
                        foodList = new ObservableCollection<Models.Food>(dataProvider.Ins.DB.Foods.Where(x => x.IsDel == false && x.IdCategory == idCategory));
                }
                else
                {
                    if (idCategory == "123987")
                        foodList = new ObservableCollection<Models.Food>(dataProvider.Ins.DB.Foods.Where(x => x.IsDel == false && x.Name.Contains(nameSearch)));
                    else
                        foodList = new ObservableCollection<Models.Food>(dataProvider.Ins.DB.Foods.Where(x => x.IdCategory == idCategory && x.Name.Contains(nameSearch)));
                }

                var list = JsonConvert.SerializeObject(foodList, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                return Json(new { code = 200, foodList = list, msg = "Tìm món thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Tìm món thât bại : " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetInforFood(string id)
        {
            try
            {
                var food = dataProvider.Ins.DB.Foods.Where(x => x.Id == id).SingleOrDefault();

                var item = JsonConvert.SerializeObject(food, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                return Json(new { code = 200, food = item, msg = "Lấy món ăn thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Không tìm thấy món : " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpLoadImg()
        {
            try
            {
                string FoldeerUpload = "Content\\UploadImg";
                string result = "";
                var fileUnload = Request.Files["File"];
                string path = AppDomain.CurrentDomain.BaseDirectory + FoldeerUpload;

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (fileUnload.FileName != "")
                {
                    var fileName = Path.GetFileName((string)fileUnload.FileName);

                    if (System.IO.File.Exists(path + fileName))
                        fileName = string.Format("{0:yyMMddHHmm-}", DateTime.Now) + fileName;

                    fileUnload.SaveAs(Path.Combine(path, fileName));

                    result = "/Content/UploadImg" + "/" + fileName;
                    Session["dataImg"] = result;
                }
                return Json(new { code = 200, urlImg = result, msg = "Tải ảnh thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Tải ảnh thất bại! " + ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult AddFood(string name, string idCategory, string note, int stock, double inputPrice, double outputPrice )
        {
            try
            {
                string urlImg = (string)Session["dataImg"];
                string Id_image = Guid.NewGuid().ToString();
                var img = new Models.Image() { Id = Id_image, Data = urlImg };
                dataProvider.Ins.DB.Images.Add(img);
                dataProvider.Ins.DB.SaveChanges();

                var food = new Food()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    IdCategory = idCategory,
                    Stock = stock,
                    IntputPrice = inputPrice,
                    OutputPrice = outputPrice,
                    IdImage = Id_image,
                    IsOutOfStock = false,
                    Note = note,
                    IsDel = false
                };
                dataProvider.Ins.DB.Foods.Add(food);
                dataProvider.Ins.DB.SaveChanges();

                return Json(new { code = 200, msg = "Thêm món thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm món thất bại : " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult EditFood(string id, string name, string idCategory, string note, int stock, double inputPrice, double outputPrice)
        {
            try
            {
                var food = dataProvider.Ins.DB.Foods.Where(x => x.Id == id).SingleOrDefault();
                var img = dataProvider.Ins.DB.Images.Where(x => x.Id == food.IdImage).SingleOrDefault();
                food.Name = name;
                food.IdCategory = idCategory;
                food.Stock = stock;
                food.IntputPrice = inputPrice;
                food.OutputPrice = outputPrice;
                food.Note = note;

                if (Session["dataImg"] != null)
                {
                    string urlImg = (string)Session["dataImg"];
                    img.Data = urlImg;
                }    
                
                dataProvider.Ins.DB.SaveChanges();

                return Json(new { code = 200, msg = "Sửa món thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Sửa món thất bại : " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteFood(string id)
        {
            try
            {
                var food = dataProvider.Ins.DB.Foods.Where(x => x.Id == id).SingleOrDefault();
                food.IsDel = true;

                dataProvider.Ins.DB.SaveChanges();

                return Json(new { code = 200, msg = "Xóa món thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Xóa món thất bại : " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
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