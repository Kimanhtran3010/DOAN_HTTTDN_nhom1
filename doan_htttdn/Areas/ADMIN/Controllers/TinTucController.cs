using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using doan_htttdn.FF;
using System.IO;
using PagedList;
using doan_htttdn.DAO;
using doan_htttdn.DAO.TinTuc;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class TinTucController : Controller
    {
        // GET: ADMIN/TinTuc
        QL_SCN db = new QL_SCN();
        DAO_TinTuc dao = new DAO_TinTuc();
        public ActionResult ListAr(string Search,int? page)
        {
            var model = dao.Get_Article();
            ViewBag.Search = Search;
            if (!string.IsNullOrEmpty(Search))
            {
                model = dao.Search_Article(Search);
            }
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            return View(model.ToPagedList(pagenumber, pagesize));


        }
        public ActionResult PartialListAr()
        {
            var model = db.ARTICLEs.Where(x => x.ID_Article > 0).ToList();
            return PartialView("PartialListAr", model);
        }
        public ActionResult ShowAr(string id)
        {
            int arid = int.Parse(id);
            var cate = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == arid);
            return View(cate);
        }

        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArticle(ARTICLE article, HttpPostedFileBase[] MultipleFiles)
        {
            if (MultipleFiles != null)
            {

                foreach (var fileBase in MultipleFiles)
                {
                    if (fileBase != null && fileBase.ContentLength > 0)
                    {

                        // Retrieve a reference to a container 
                        var path = Path.Combine(Server.MapPath("~/Assets/Image/IMGAR"), article.ID_Article + "_" + article.ID_Menu + ".jpg");
                        fileBase.SaveAs(path);
                    }

                }
            }
            article.Image = article.ID_Article + "_" + article.ID_Menu + ".jpg";
            if (dao.Insert_Article(article))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công!');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("AddArticle", "TinTuc");
            }
        }
        public ActionResult EditArticle(string id)
        {
            var bien = dao.Get_DetailArticle(id);
            return View(bien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArticle(ARTICLE article, HttpPostedFileBase[] MultipleFiles)
        {
            if (MultipleFiles != null)
            {

                foreach (var fileBase in MultipleFiles)
                {
                    if (fileBase != null && fileBase.ContentLength > 0)
                    {

                        // Retrieve a reference to a container 
                        var path = Path.Combine(Server.MapPath("~/Assets/Image/IMGAR"), article.ID_Article + "_" + article.ID_Menu +".jpg");
                        fileBase.SaveAs(path);
                    }

                }
            }
            article.Image = article.ID_Article + "_" + article.ID_Menu + ".jpg";
            if (dao.Update_ARTICLEs(article))
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thành Công!');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("EditArticle", "TinTuc");
            }
        }

        //public ActionResult DeleteAr(string id)
        //{
        //    Delte(id);

        //    return View("ListAr");
        //}

        //[HttpPost]
        //private void Delte(string id)
        //{
        //    int cateid = int.Parse(id);
        //    var model = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == cateid);
        //    db.ARTICLEs.Remove(model);
        //    db.SaveChanges();
        //}

        public ActionResult DeleteAr(string id)
        {
            if (dao.Delete_Article(id) == true)
            {
                TempData["msg"] = "<script>alert('Xóa Thành Công!');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }
            else
            {
                TempData["msg"] = "<script>alert('Xóa Không Thành Công! Lỗi');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }

        }




        public ActionResult Index()
        {
            return View();
        }
    }
}