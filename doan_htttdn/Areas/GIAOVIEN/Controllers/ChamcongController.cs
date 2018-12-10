using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO.GIAOVIEN;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class ChamcongController : Controller
    {
        // GET: GIAOVIEN/Chamcong
        DAO_Teaching_class dao = new DAO_Teaching_class();
        public ActionResult Index( )
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
               
                var list = dao.GetALL((int)Session[Common.CommonConstant.ID_SESSION]);
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
    }
}