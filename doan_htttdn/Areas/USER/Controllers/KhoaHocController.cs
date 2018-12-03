using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.Areas.USER.Models;
using PagedList;
using doan_htttdn.FF;


namespace doan_htttdn.Areas.USER.Controllers
{
    public class KhoaHocController : Controller
    {
        // GET: USER/KhoaHoc
        public ActionResult Index(string searchString, int? page, string age, string PriceSort, string AgeSort)
        {
            var dao = new KhoaHocModel();
            var model = dao.GetCOURSEs();
            //page
            if (searchString != null && page <= 1)
            {
                page = 1;
            }
            if (PriceSort != null && page <= 1)
            {
                page = 1;
            }
            if (AgeSort != null && page <= 1)
            {
                page = 1;
            }
            ViewBag.AgeSort = AgeSort;
            ViewBag.PriceSort = PriceSort;
            ViewBag.searchString = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = dao.SearchCOURSEs(searchString);
            }
            if (!string.IsNullOrEmpty(PriceSort))
            {
                model = dao.FilterCOURSEsByPrice(PriceSort);
            }
            if (!string.IsNullOrEmpty(AgeSort))
            {
                model = dao.FilterCOURSEsByAge(AgeSort);
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
            //return View(model);
        }
        [HttpGet]
        public ActionResult ChiTiet(string ID)
        {
            if (string.IsNullOrEmpty(ID))
                return Redirect("Index");
            var dao = new KhoaHocModel();
            var model = dao.GetCOURSE(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            if (string.IsNullOrEmpty(collection["ADDRESS"]) || string.IsNullOrEmpty(collection["BIRTHDAY"])
                || string.IsNullOrEmpty(collection["Email"]) || string.IsNullOrEmpty(collection["IDCourse"])
                || string.IsNullOrEmpty(collection["NameParent"]) || string.IsNullOrEmpty(collection["NameStudent"])
                || string.IsNullOrEmpty(collection["Phone"]) )
            {
                ViewBag.ErrorMsg = "Đăng kí thất bại, vui lòng thử lại sau";
                ViewBag.IDCourse = collection["IDCourse"];
                ViewBag.Name = collection["Name"];
                return View("Register");
            }
            RIGISTRATION_COURSE rc = new RIGISTRATION_COURSE();
            var model = new KhoaHocModel();
            rc.ADDRESS = collection["ADDRESS"];
            rc.BIRTHDAY = DateTime.Parse(collection["BIRTHDAY"]);
            rc.Email = collection["Email"];
            rc.IDCourse = collection["IDCourse"];
            rc.NameParent = collection["NameParent"];
            rc.NameStudent = collection["NameStudent"];
            rc.Phone = collection["Phone"];

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            rc.IDRegist = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            rc.DayRegist = DateTime.Today;
            rc.State = "Chưa Duyệt";
            bool rs = model.Insert(rc);
            if (rs)
            {
                return RedirectToAction("Index", "KhoaHoc");
            }
            else
            {
                ViewBag.IDCourse = collection["IDCourse"];
                ViewBag.Name = collection["Name"];
                ViewBag.ErrorMsg = "Đăng kí thất bại, vui lòng thử lại sau";
                return View("Register");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            if (string.IsNullOrEmpty(Request.QueryString["Name"]) || string.IsNullOrEmpty(Request.QueryString["Id"]))
                return RedirectToAction("Index", "KhoaHoc");
            return View();

        }
    }
}