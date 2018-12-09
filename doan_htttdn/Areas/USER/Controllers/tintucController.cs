using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
//using doan_htttdn.Areas.USER.Models;
using System.IO;
//using doan_htttdn.Areas.ViewModel;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.USER.Controllers
{
    public class tintucController : Controller
    {


        // GET: USER/tintuc

        QL_SCN db = new QL_SCN();

        public ActionResult ListAr()
        {
            var a = db.ARTICLEs.Where(x => x.ID_Article > 0).ToList();
            return View(a);
        }
       
        public ActionResult PartialListAr()
        {
            var a = db.ARTICLEs.Where(x => x.ID_Article > 0).ToList();
            return PartialView("PartialListAr",a);
        }
        public ActionResult ShowAr(string id)
        {
            int Aid = int.Parse(id);
            var a = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == Aid);
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
            var ar = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == arid);
            db.ARTICLEs.Remove(ar);
            db.SaveChanges();
        }
        public ActionResult EditAr(string id)
        {
            int Air = int.Parse(id);
            var a = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == Air);
            return View(a);
        }
        [HttpPost]
        public ActionResult EditAr(ARTICLE di)
        {
            ARTICLE ar = new ARTICLE();
            ar.ID_Article = di.ID_Article;
            ar.Title = di.Title;
            ar.Summary = di.Summary;
            ar.Contents = di.Contents;
            ar.Image = di.Image;
            ar.Day = di.Day;
            ar.IDAdmin = di.IDAdmin;
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

        //public ActionResult Examdropdown()
        //{
        //    var cate = db.Article1.Where(x => x.ID_Article > 0).ToList();
        //    List<object> obj = new List<object>();
        //    foreach (var item in cate)
        //    {
        //        obj.Add(new { Text = item.Title, Value = item.ID_Article });
        //    }

      
     

        


        //public ActionResult Examdropdown()
        //{
        //    var cate = db.ARTICLEs.Where(x => x.ID_Article > 0).ToList();
        //    List<object> obj = new List<object>();
        //    foreach (var item in cate)
        //    {
        //        obj.Add(new { Text = item.Title, Value = item.ID_Article });
        //    }

        //    var model = new DropDownList()
        //    {
        //        selectlistar = new SelectList(obj.ToList(), "Value", "Text")
        //    };
        //    return View(model);
        //}

        //public ActionResult ChooseCheck()
        //{
        //    var cate = db.ARTICLEs.Where(x => x.ID_Article > 0).ToList();
        //    var model = new CheckBoxList
        //    {
        //        AvariableCheck = cate
        //    };

        //    model.SelectedCheck = new List<ARTICLE> { cate[1], cate[2] };
        //    return View(model);
        //}
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
            var model = db.ARTICLEs.Where(x => x.State > 0).ToList();
            return View(model);
        }

        public ActionResult Detail(string id)
        {
            //id = 1;
            if (id!=null)
            {
                var model = db.ARTICLEs.FirstOrDefault(xx => xx.ID_Article == int.Parse(id));
                ViewBag.title = model.Title;
                ViewBag.abtract = model.Summary;
                ViewBag.detail = model.Contents;
                ViewBag.image = model.Image;
                ViewBag.ad = model.IDAdmin;

            }
            return View();
        }
        
        //public ActionResult InNewscate (string cateid)
        //{
        //    if (cateid != null)
        //    {
        //        int idcate = int.Parse(cateid);
        //        var model = db.ARTICLEs.Where(x => x.ID_Menu == idcate).ToList();

        //        var cate = db.Menu_Article.FirstOrDefault(x => x.ID_Menu == idcate);
        //        ViewBag.catename = cate.Name_Menu;
        //        return View(model);
        //    }
        //    else {
        //        return View("Index","tintuc");
        //    }
            
        //}
    //    public ActionResult Menu()
    //    {
    //        var model = db.Menu_Article.Where(x => x.ID_Menu > 0).ToList();
    //        return View(model);
    //    }
   }
}