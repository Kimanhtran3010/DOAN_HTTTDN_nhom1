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
            //Session.Add(CommonConstant.USER_SESSION, null);
            //Session.Add(CommonConstant.ID_SESSION, null);
            //Session.Add(CommonConstant.USER_STATE,null);
            //Session.Add(CommonConstant.ID_TEACHING_CLASS, null);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ACCOUNT objUser)
        {

            if (ModelState.IsValid) // kiem tra rong
            {
                var dao = new DAO_GIAOVIEN();
                var obj = dao.Login_Giaovien(objUser.Username, Encryptor.MD5Hash(objUser.Password).ToString());
                if (obj == 1)
                {
                    var _teacher = dao.GetbyAccpunt(objUser.Username, Encryptor.MD5Hash(objUser.Password).ToString());
                    var userTeacher = new SessionTeacher ();
                    userTeacher.IDuser = _teacher.IDTeacher;
                    userTeacher.user = dao.GetbyID(_teacher.IDTeacher).Name;
                    userTeacher.state = 1;
                    Session.Add(CommonConstant.USER_SESSION, userTeacher.user);
                    Session.Add(CommonConstant.ID_SESSION, userTeacher.IDuser);
                    Session.Add(CommonConstant.USER_STATE, userTeacher.state);
                    Session.Add(CommonConstant.ID_TEACHING_CLASS,null);
                    Session.Add(CommonConstant.ID_CLASS, null);
                    return RedirectToAction("Index", "thongtin");
                }
                else if (obj == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");

//                }
//                else if (obj == -1)
//                {
//                    ModelState.AddModelError("", "Tài Khoản Đang bị Khóa");
//                }
//                else if (obj == -2)
//                {
//                    ModelState.AddModelError("", "Mật Khẩu Không Đúng");
//                }
//                else
//                    ModelState.AddModelError("", "Đăng Nhập Không Đúng");

//            }


//            return View("Index");
//        }
//    }
//}