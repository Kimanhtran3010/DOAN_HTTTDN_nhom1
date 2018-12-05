using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class HomeController : Controller
    {
        // GET: ADMIN/Home
        public ActionResult Index()
        {
            if(Session[Common.CommonConstant.USER_SESSION] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
    }
}