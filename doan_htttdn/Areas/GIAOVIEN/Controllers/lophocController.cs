using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class lophocController : Controller
    {
        DAO_Course dao_course = new DAO_Course();
        DAO_Lop dao_lop = new DAO_Lop();
        // GET: GIAOVIEN/lophoc
        public ActionResult Index()
        {
           
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                var a = dao_lop.GetByIDTeacher((int)Session[Common.CommonConstant.ID_SESSION]);
                PopulateCoursetsDropDownList();
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        private void PopulateCoursetsDropDownList(object selectedDepartment = null)
        {
            ViewBag.CoursesList = new SelectList(dao_course.GetNamecouse(),"IDCourse","Name");
        }
        [HttpPost]
        public ActionResult Search( string search_table)
        {
            var a = dao_lop.GetByIDTeacherandNameCourse((int)Session[Common.CommonConstant.ID_SESSION], search_table);
            PopulateCoursetsDropDownList();
            return RedirectToAction("Index","lophoc");
            //return View(a);
        }
        public ActionResult Xem_DShocvien(int IDclass = 1 )
        {
            return RedirectToAction("Index", "DShocvien", new {@id = IDclass });
        }

    }
}