using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using doan_htttdn.Areas.USER.Models;
using System.IO;
using doan_htttdn.Areas.ViewModel;

namespace doan_htttdn.Areas.USER.Controllers
{
    public class tintucController : Controller
    {


        // GET: USER/tintuc

        Web1 db = new Web1();

        public ActionResult ListAr()
        {
            var a = db.Article1.Where(x => x.ID_Article > 0).ToList();
            return View(a);
        }
       
        public ActionResult PartialListAr()
        {
            var a = db.Article1.Where(x => x.ID_Article > 0).ToList();
            return PartialView("PartialListAr",a);
        }
        public ActionResult ShowAr(string id)
        {
            int Aid = int.Parse(id);
            var a = db.Article1.FirstOrDefault(x => x.ID_Article == Aid);
            return View(a);
        }

        public ActionResult DeleteAr(string id)
        {
            Delete(id);
            return Content("Xoa thanh cong !!!");
        }
        [HttpPost]
        private void Delete(string id)
        {
            int arid = int.Parse(id);
            var ar = db.Article1.FirstOrDefault(x => x.ID_Article == arid);
            db.Article1.Remove(ar);
            db.SaveChanges();
        }
        public ActionResult EditAr(string id)
        {
            int Air = int.Parse(id);
            var a = db.Article1.FirstOrDefault(x => x.ID_Article == Air);
            return View(a);
        }
        [HttpPost]
        public ActionResult EditAr(Article1 di)
        {
            Article1 ar = new Article1();
            ar.ID_Article = di.ID_Article;
            ar.Title = di.Title;
            ar.Summary = di.Summary;
            ar.Contents = di.Contents;
            ar.Image = di.Image;
            ar.Day = di.Day;
            ar.ID_Admin = di.ID_Admin;
            db.Entry(ar).State = EntityState.Modified;
            db.SaveChanges();
            return View("ListAr");
        }
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Index(Admin_Article ad)
        {
            if (ModelState.IsValid)
            {
                //creat
                db.Admin_Article.Add(ad);
                db.SaveChanges();


            }
            return Content("Success!!!");
        }

        public ActionResult Examdropdown()
        {
            var cate = db.Article1.Where(x => x.ID_Article > 0).ToList();
            List<object> obj = new List<object>();
            foreach (var item in cate)
            {
                obj.Add(new { Text = item.Title, Value = item.ID_Article });
            }

            var model = new DropDownList()
            {
                selectlistar = new SelectList(obj.ToList(), "Value", "Text")
            };
            return View(model);
        }

        public ActionResult ChooseCheck()
        {
            var cate = db.Article1.Where(x => x.ID_Article > 0).ToList();
            var model = new CheckBoxList
            {
                AvariableCheck = cate
            };
            
            model.SelectedCheck = new List<Article1> { cate[1], cate[2] };
            return View(model);
        }
        [HttpPost]
        public ActionResult ChooseCheck(int[] choosedcheck)
        {
            return View();
        }

        public ActionResult Ckeditor()
        {
            return View();
        }

        public ActionResult ListNews()
        {
            var model = db.Article1.Where(x => x.ID_Admin >= 1).ToList();
            return View(model);
        }
        //public ActionResult SaveUploadedFile()
        //{
        //    bool isSavedSuccessfully = true;
        //    string fName = "";
        //    foreach (string fileName in Request.Files)
        //    {
        //        HttpPostedFileBase file = Request.Files(fileName);
        //        // save file content goes here
        //        fName = file.FileName;
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            var originaDirectory = new DirectoryInfo(string.Format("{0}Image\\WallImages", Server.MapPath(@"\")));
        //            string pashString = System.IO.Path.Combine(originaDirectory.ToString(),"imagepath");
        //            var fileName1 = Path.GetFileName(file.FileName);
        //            bool isExists = System.IO.Directory.Exists(pashString);

        //            if (!isExists)
        //            {
        //                System.IO.Directory.CreateDirectory(pashString);
        //            }
        //            var path = string.Format("{0}\\{1}", pashString, file.FileName);
        //            file.SaveAs(path);

        //        }
        //    }
        //    if (isSavedSuccessfully)
        //    {
        //        return Json(new { Message = fName });
        //    }
        //    else
        //    {
        //        return Json(new { Message = "Error in saving file" });
        //    }
        //}
        //public ActionResult UploadImage()
        //{

        //    return View();
        //}



    }
}