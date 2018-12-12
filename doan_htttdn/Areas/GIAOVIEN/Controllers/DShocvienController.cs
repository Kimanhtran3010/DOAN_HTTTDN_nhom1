using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO.GIAOVIEN;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class DShocvienController : Controller
    {
        DAO_Hocvien dao = new DAO_Hocvien();
        // GET: GIAOVIEN/DShocvien
      
        public ActionResult Index( int x = 1 )
        {
            //var a = dao.GetbyIDClass(x);
            //  return View(a);
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {

                var a = dao.GetbyIDClass(1);
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


    }
}