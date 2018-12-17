using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO;
using PagedList;
using doan_htttdn.FF;


namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class RoBoController : Controller
    {
        private QL_SCN db = new QL_SCN();
        DAO_Product dp = new DAO_Product();
        PRODUCT pr = new PRODUCT();
        private object list1;
        // GET: ADMIN/RoBo
        public ActionResult RoBo(string tk , int? Page)
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                if (tk == null)
                {
                    list1 = dp.listpd(Page ?? 1, 5);
                }
                else
                {
                    list1 = dp.search(tk, 1, 5);
                }
                return View(list1);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ADMIN/RoBo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ADMIN/RoBo/Create
        public ActionResult Them()
        {
            return View();
        }

        // POST: ADMIN/RoBo/Create
        [HttpPost]
        public ActionResult Them(PRODUCT pd)
        {
            try
            {
                db.PRODUCTs.Add(pd);
                db.SaveChanges();
                TempData["msg"] = "<script>alert('Thêm Thành Công');</script>";
                return RedirectToAction("Them", "Robo");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "RoBo");
            }
        }

        // GET: ADMIN/RoBo/Edit/5
        public ActionResult Sua(string id)
        {
            var list = dp.ViewDetail(id);
            return View(list);
        }

        // POST: ADMIN/RoBo/Edit/5
        [HttpPost]
        public ActionResult Sua(PRODUCT pd)
        {
            
                if (dp.Update(pd)) {
                    // TODO: Add update logic here
                    TempData["msg"] = "<script>alert('Cập Nhật Thành Công');</script>";
                    return RedirectToAction("RoBo", "RoBo"); 
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Sua", "RoBo");
            }
        
        }

     

        public ActionResult Delete(string id)
        {
            var pr = db.PRODUCTs.Find(id);
            db.PRODUCTs.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("RoBo", "RoBo");
        }

        // POST: ADMIN/RoBo/Delete/5
       
    }
}
