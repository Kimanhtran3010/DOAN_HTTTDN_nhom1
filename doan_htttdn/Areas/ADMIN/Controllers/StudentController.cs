using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO;
using PagedList;

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
    }
}