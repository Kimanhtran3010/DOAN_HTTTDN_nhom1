using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.FF;
using PagedList;

namespace doan_htttdn.Areas.USER.Controllers
{
    public class TinTucController : Controller
    {
        // GET: USER/TinTuc
        QL_SCN db = new QL_SCN();
        public ActionResult ListAr()
        {
            
            return View();
        }
        public ActionResult PartialListAr()
        {
            var model = db.ARTICLEs.Where(x => x.ID_Article > 0).ToList();
            return PartialView("PartialListAr",model);
        }
        public ActionResult Showar(string id)
        {
            int arid = int.Parse(id);
            var cate = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == arid);
            return View(cate);
        }
        public ActionResult Aredit(string id)
        {
            int cateid = int.Parse(id);
            var cate = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == cateid);
            return View(cate);
        }
        [HttpPost]
        public ActionResult Aredit(ARTICLE model)
        {
            ARTICLE cate = new ARTICLE();
            cate.ID_Article = model.ID_Article;
            cate.Title = model.Title;
            cate.Summary = model.Summary;
            cate.Contents = model.Contents;
            cate.Image = model.Image;
            cate.Day = model.Day;
            cate.State = model.State;
            cate.IDAdmin = model.IDAdmin;
            cate.ID_Menu = model.ID_Menu;
            db.Entry(cate).State = EntityState.Modified;
            db.SaveChanges();
            return View("ListAr");
        }
        public ActionResult EditAr()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditAr(ARTICLE ar)
        {
            if (ModelState.IsValid)
            {
                db.ARTICLEs.Add(ar);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult ListNews()
        {
            var model = db.ARTICLEs.Where(x => x.ID_Article > 1).ToList();
            return View(model);
        }

        public ActionResult ListNews_1()
        {
            var model = db.ARTICLEs.Where(x => x.ID_Article > 1).ToList() ;
            return View(model);
        }


        public ActionResult InNewscate(string cateid, int? page)
        {
            if (cateid != null)
                {
                ViewBag.cateid = cateid;
                int idcate = int.Parse(cateid);
                var model = db.ARTICLEs.Where(x => x.ID_Menu == idcate).ToList();
                var cate = db.Menu_Article.FirstOrDefault(x => x.ID_Menu == idcate);
                ViewBag.cateName = cate.Name_Menu;
                int pagesize = 3;
                int pagenumber = (page ?? 1);
                return View(model.ToPagedList(pagenumber,pagesize));
            }
          else
            {
                return View("Index","TinTuc");
            }
            
        }

        [HttpGet]
        public ActionResult Detail (long id)
        {
            if (id > 0 )
            {
                var cate = db.ARTICLEs.Where(x => x.ID_Article == id).FirstOrDefault();
                ViewBag.tieude = cate.Title;
                ViewBag.summary = cate.Summary;
                ViewBag.content = cate.Contents;
                ViewBag.img = cate.Image;
                ViewBag.date = cate.Day;
                
                return View();
            }
           else
            {
                return Content("Error !!!");
            }
            
        }
        public ActionResult Menu()
        {
            var model = db.Menu_Article.Where(x => x.ID_Menu > 0).ToList();
            return View(model);
        }

        

    }
}