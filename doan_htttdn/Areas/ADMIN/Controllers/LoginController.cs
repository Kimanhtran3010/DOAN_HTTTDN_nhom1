using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using doan_htttdn.DAO;
using doan_htttdn.FF;
using doan_htttdn.Common;
using doan_htttdn.DAO;

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
        public ActionResult Login(doan_htttdn.FF.Admin_Article objUser)
        {

            if (ModelState.IsValid) // kiem tra rong
            {
                var dao = new DAO_Admin();
                var obj = dao.Login(objUser.IDAdmin, Encryptor.MD5Hash(objUser.Pass).ToString());
                if (obj == 1)
                {

                    var userSession = new UserLogin();
                    userSession.IDuser = objUser.IDAdmin.ToString();
                    Session.Add(CommonConstant.USER_SESSION, userSession.IDuser);
                    return RedirectToAction("Index", "Home");
                }
                else if (obj == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");

                }
                else if (obj == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản Đang bị Khóa");
                }
                else if (obj == -2)
                {
                    ModelState.AddModelError("", "Mật Khẩu Không Đúng");
                }
                else
                    ModelState.AddModelError("", "Đăng Nhập Không Đúng");

            }


            return View("Index");
        }

        public ActionResult UserDashBoard()
        {
            if (Session[CommonConstant.USER_SESSION] != null)
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