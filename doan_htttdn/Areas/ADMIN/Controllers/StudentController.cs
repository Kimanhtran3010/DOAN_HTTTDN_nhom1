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
            if (Session[Common.CommonConstant.USER_SESSION] != null)
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
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
                TempData["msg"] = "<script>alert('Không Được Xóa Học Sinh !');</script>";
                return RedirectToAction("Student");
            }
        }

        public ActionResult ChonLop(int id, int? page)
        {
            var model = dao.Get_Class();
            ViewBag.IDStudent = id;
            int pagesize = 15;
            int pagenumber = (page ?? 1);
            return View(model.ToPagedList(pagenumber, pagesize));
        }
        [HttpPost]
        public ActionResult ThemN(int[] a, int id_student)
        {
            
           for (int i=1; i<= a.Length; i++)
            {
                if (dao.Check(id_student, a[i]))
                {
                    dao.Class_student(id_student, a[i]);
                }
                else
                {
                    return Content("Lỗi!");
                }
                    
            }
           return Content("Thêm Lớp cho học viên thành công !");
        }
        
    }
}