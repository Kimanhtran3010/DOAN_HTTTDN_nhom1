using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.Areas.GIAOVIEN.Models;
using doan_htttdn.DAO.GIAOVIEN;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class DShocvienController : Controller
    {
        DAO_Hocvien dao = new DAO_Hocvien();
        // GET: GIAOVIEN/DShocvien
      
        public ActionResult Index( )
        {

            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                var a = dao.GetALL((int)Session[Common.CommonConstant.ID_SESSION]);
                SetViewBag1();
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }


        public ActionResult Xem_DShocvien(int id)
        {
            
            IEnumerable<STUDENT> ds = dao.GetbyIDClass(id);
            SetViewBag1();
            return View("Index",ds);
        }
        public ActionResult Searchlop(int IDClass)
        {
            IEnumerable<STUDENT> ds = dao.GetbyIDClass(IDClass);
            SetViewBag1();
            return View("Index", ds);
        }
        private void SetViewBag1(string selectName = null)// ma lop // dung de tim kiem
        {
            DAO_Lop daolop = new DAO_Lop();
            var lop1 = daolop.GetByIDTeacher((int)Session[Common.CommonConstant.ID_SESSION]);
            ViewBag.IDClass = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
    }
}