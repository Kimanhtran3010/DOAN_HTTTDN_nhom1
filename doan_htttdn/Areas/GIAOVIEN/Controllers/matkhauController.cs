using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO.GIAOVIEN;
using doan_htttdn.Areas.GIAOVIEN.Models;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class matkhauController : Controller
    {
        DAO_Acount dao = new DAO_Acount();
        // GET: GIAOVIEN/matkhau
        public ActionResult Index()
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult ChangePassword( Acount_model model)
            
        {
           
            model.IDTeacher = (int)Session[Common.CommonConstant.ID_SESSION];
            if(dao.Change_Pass(model) == 0)
            {
                TempData["msg"] = "<script>alert('Thay đổi mật khẩu thành công');</script>";
            }
            else
            {
                if(dao.Change_Pass(model) == 1)
                {
                    TempData["msg"] = "<script>alert('Mật khẩu cũ không đúng');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Không tồn tại tài khoản');</script>";
                }
            }
            return RedirectToAction("Index", "matkhau");
        }
    }
}