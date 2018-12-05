using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using doan_htttdn.Areas.USER.Models;

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




    }
}