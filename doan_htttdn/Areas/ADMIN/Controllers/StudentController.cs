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
    public class StudentController : Controller
    {
        // GET: ADMIN/Student
        DAO_Admin dao = new DAO_Admin();
        public ActionResult Student(string Search, int? page)
        {
            var model = dao.List_Student();
            ViewBag.Search = Search;
            if (!string.IsNullOrEmpty(Search))
            {
                model = dao.Search_Student(Search);
            }
            int pagesize = 15;
            int pagenumber = (page ?? 1);
            return View(model.ToPagedList(pagenumber, pagesize));
        }

        
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(STUDENT student)
        {
            if (dao.Insert_Student(student))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công !');</script>";
                return RedirectToAction("Student");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Không Thành Công !');</script>";
                return RedirectToAction("Student");
            }
        }

        public ActionResult Sua(int id)
        {
            var bien = dao.Get_student(id);
            return View(bien);
        }
        [HttpPost]
        public ActionResult Sua(STUDENT student)
        {
            if (dao.Update_Student(student))
            {
                TempData["msg"] = "<script>alert('Sửa Thành Công !');</script>";
                return RedirectToAction("Student");
            }
            else
            {
                TempData["msg"] = "<script>alert('Sửa Không Thành Công !');</script>";
                return RedirectToAction("Student");
            }
        }
        
        public ActionResult xoa(int id)
        {
            if (dao.Delete_Student(id))
            {
                TempData["msg"] = "<script>alert('Xóa Thành Công !');</script>";
                return RedirectToAction("Student");
            }
            else
            {
                TempData["msg"] = "<script>alert('Xóa Không Thành Công !');</script>";
                return RedirectToAction("Student");
            }
        }
    }
}