using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO;
using PagedList;
using doan_htttdn.FF;
using System.IO;

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
        [ValidateAntiForgeryToken]
        public ActionResult Them(COURSE course, HttpPostedFileBase[] MultipleFiles)
        {
            if (MultipleFiles != null)
            {
 
                foreach (var fileBase in MultipleFiles)
                {
                    if (fileBase != null && fileBase.ContentLength > 0)
                    {

                        // Retrieve a reference to a container 
                        var path = Path.Combine(Server.MapPath("~/Assets/Image"), course.IDCourse+ "1.jpg");
                        fileBase.SaveAs(path);
                    }

                }
            }
            course.Image = "~/Assets/Image/" + course.IDCourse + "1.jpg";
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
        public ActionResult Sua(string id)
        {
            var bien = dao.Get_DetailCourse(id);
            return View(bien);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua(COURSE course, HttpPostedFileBase[] MultipleFiles)
        {
            if (MultipleFiles != null)
            {

                foreach (var fileBase in MultipleFiles)
                {
                    if (fileBase != null && fileBase.ContentLength > 0)
                    {

                        // Retrieve a reference to a container 
                        var path = Path.Combine(Server.MapPath("~/Assets/Image"), course.IDCourse + "update.jpg");
                        fileBase.SaveAs(path);
                    }

                }
            }
            course.Image = "~/Assets/Image/" + course.IDCourse + "update.jpg";
            if (dao.Update_Course(course))
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thành Công!');</script>";
                return RedirectToAction("Course", "Course");
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Sua", "Course");
            }
        }
        
        public ActionResult Xoa(string id)
        {
            if (dao.Delete_Course(id))
            {
                TempData["msg"] = "<script>alert('Xóa Thành Công!');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Xóa Không Thành Công! Lỗi');</script>";
            }

            return RedirectToAction("Course", "Course");
        }
    }
}