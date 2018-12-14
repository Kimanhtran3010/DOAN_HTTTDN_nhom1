﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO;
using PagedList;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class ClassController : Controller
    {
        // GET: ADMIN/Class
        DAO_Admin dao = new DAO_Admin();
        public ActionResult Index(string Search, int? page)
        {
            var model = dao.Get_Class();
            ViewBag.Search = Search;
            if (!string.IsNullOrEmpty(Search))
            {
                model = dao.Search_Class(Search);
            }
            int pagesize = 15;
            int pagenumber = (page ?? 1);
            return View(model.ToPagedList(pagenumber, pagesize));
        }

        private void set_viewbag()
        {
            var lop = dao.GetName_Course();
            ViewBag.IDCourse = new SelectList(lop.ToList(), "IDCourse", "Name");
        }
         public ActionResult Them()
        {
            set_viewbag();
            return View();
        }

        [HttpPost]
        public ActionResult Them(CLASS lop)
        {
            if (dao.Insert_Class(lop))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công');</script>";
                return RedirectToAction("Index", "Class");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "Class");
            }
        }

        public ActionResult Sua(int id)
        {
            var model = dao.Get_DetailClass(id);
            set_viewbag();
            return View(model);
        }

        [HttpPost]
        public ActionResult Sua(CLASS lop)
        {
            if (dao.Update_Class(lop))
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thành Công');</script>";
                return RedirectToAction("Index", "Class");
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Sua", "Class");
            }
        }

    }
}