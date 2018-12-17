﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO.ADMIN;
using PagedList;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class Phanbo_giangdayController : Controller
    {
        // GET: ADMIN/Phanbo_giangday
        DAO_Teaching_class dao = new DAO_Teaching_class();
        public ActionResult Index(int? page)
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                var model = dao._GetAllPhanphoi();
                SetViewBagLop();
                SetViewBagTeacher();
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View(model.ToPagedList(pagenumber, pagesize));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public void SetViewBagLop()
        {
            var list = dao.GetAllClass();
            ViewBag.lop = new SelectList(list.ToList(), "IDClass", "NameClass");
        }
        public void SetViewBagTeacher()
        {
            var list = dao.GetAllTeacher();
            ViewBag.teacher = new SelectList(list.ToList(), "IDTeacher", "Name");
        }
        public void SetViewBagLop1()
        {
            var list = dao.GetAllClass();
            ViewBag.lop1 = new SelectList(list.ToList(), "IDClass", "NameClass");
        }
        public void SetViewBagTeacher1()
        {
            var list = dao.GetAllTeacher();
            ViewBag.teacher1 = new SelectList(list.ToList(), "IDTeacher", "Name");
        }
        public ActionResult Search(int lop, int? teacher, int? page)
        {
            if (teacher != null)
            {
                var model = dao._GetphabobyIDlopandIDteacher(lop,(int)teacher);
                SetViewBagLop();
                SetViewBagTeacher();
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View("Index", model.ToPagedList(pagenumber, pagesize));
                // return View("Index", model);
            }
            else
            {
                var model = dao._GetphabobyIDlop(lop);
                SetViewBagLop();
                SetViewBagTeacher();
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View("Index", model.ToPagedList(pagenumber, pagesize));
                //return View("Index", model);
            }

        }
        [HttpPost]
        public ActionResult themGV(int lop, int gv)
        {
            //LoaiSP emp = db.LoaiSPs.Where(e => e.MaLoai == id).FirstOrDefault();
            if (dao.Add_phanbo(lop,gv))
            {
             
                return Content("Thêm thành công!");
            }
            else
            {
                return Content("Thêm không thành công, bạn đã phân bổ đối tượng này!");
            } 
            
        }
        public ActionResult Deletephanbo(int id , int id1, int? page)
        {
            if(dao.Delete_phanbo(id, id1))
            {
                TempData["msg"] = "<script>alert('Xóa Thành công');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Xóa không Thành công');</script>";
            }
            var model = dao._GetAllPhanphoi();
            SetViewBagLop();
            SetViewBagTeacher();
            int pagesize = 15;
            int pagenumber = (page ?? 1);
            return View("Index", model.ToPagedList(pagenumber, pagesize));
        }
    }
}