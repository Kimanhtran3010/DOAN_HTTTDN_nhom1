using doan_htttdn.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.FF;
using doan_htttdn.Common;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class LoginController : Controller
    {
        // GET: GIAOVIEN/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ACCOUNT objUser)
        {

            if (ModelState.IsValid) // kiem tra rong
            {
                var dao = new DAO_GIAOVIEN();
                var obj = dao.Login_Giaovien(objUser.IDTeacher, Encryptor.MD5Hash(objUser.Password).ToString());
                if (obj == 1)
                {

                    var userTeacher = new SessionTeacher ();
                    userTeacher.IDuser = objUser.IDTeacher;
                    userTeacher.user = dao.GetbyID(objUser.IDTeacher).Name;
                    Session.Add(CommonConstant.USER_SESSION, userTeacher.user);
                    Session.Add(CommonConstant.ID_SESSION, userTeacher.IDuser);
                    return RedirectToAction("Index", "thongtin");
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
    }
}