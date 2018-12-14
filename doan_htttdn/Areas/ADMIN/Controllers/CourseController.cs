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
    public class CourseController : Controller
    {
        // GET: ADMIN/Course

        DAO_Admin dao = new DAO_Admin();
        public ActionResult Course(string Search, int? page)
        {
            var model = dao.Get_Course();
            if (!string.IsNullOrEmpty(Search))
            {
                model = dao.Search_Course(Search);
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
        public ActionResult Them(COURSE course)
        {
            if (dao.Insert_Course(course))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công!');</script>";
                return RedirectToAction("Course", "Course");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "Course");
            }
        }
        //public ActionResult Sua(int id)
        //{

        //}
    }
}