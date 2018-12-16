using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.FF;
using doan_htttdn.DAO;
using doan_htttdn.Common;
using PagedList;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: ADMIN/GiaoVien

        DAO_Admin dao = new DAO_Admin();
        public ActionResult GiaoVien(string Search, int? page)
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                var model = dao.List_Teacher();
                ViewBag.Search = Search;
                if (!string.IsNullOrEmpty(Search))
                {
                    model = dao.Search_Teacher(Search);
                }
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View(model.ToPagedList(pagenumber, pagesize));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(TEACHER teacher)
        {

            if (dao.Insert_Teacher(teacher))
            {
                return RedirectToAction("GiaoVien");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "GiaoVien");
            }
        }



        public ActionResult Sua(int id)
        {
            var bien = dao.Get_Teacher(id);
            return View(bien);
        }
        [HttpPost]
        public ActionResult Sua(TEACHER teacher)
        {
            if (ModelState.IsValid)
            {
                if (dao.Update_Teacher(teacher))
                {
                    TempData["msg"] = "<script>alert('Cập Nhật Thành Công !');</script>";
                    RedirectToAction("GiaoVien");
                }
                else
                    TempData["msg"] = "<script>alert('Cập Nhật Không Thành Công !');</script>";

            }
            return RedirectToAction("Sua","GiaoVien");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (dao.Delete_Teacher(id) == true)
            {
                TempData["msg"] = "<script>alert(' Thành Công !');</script>";
                return RedirectToAction("GiaoVien", "GiaoVien");
            }
            else
            {
                TempData["msg"] = "<script>alert('Lỗi Xóa Không Thành Công !');</script>";
                return RedirectToAction("GiaoVien", "GiaoVien");
            }


        }


    }
}