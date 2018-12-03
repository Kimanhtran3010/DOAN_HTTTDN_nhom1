using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO;
using doan_htttdn.FF;
using doan_htttdn.Common;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class LoginController : Controller
    {
        // GET: ADMIN/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(doan_htttdn.FF.ADMIN objUser)
        {
            
            if (ModelState.IsValid) // kiem tra rong
            {
                 var dao = new DAO_Admin();
                var obj = dao.Login(objUser.IDAmin, objUser.Password);
                if (obj != null)
                {
                    var userSession = new UserLogin();
                    userSession.IDuser = obj.IDAmin;
                    Session.Add(CommonConstant.USER_SESSION, userSession.IDuser);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");

                }
            }
           

            return View("Index");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}