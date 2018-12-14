//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using doan_htttdn.DAO;
//using doan_htttdn.FF;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class thongtinController : Controller
    {
        // GET: GIAOVIEN/thongtin
        DAO_GIAOVIEN dao = new DAO_GIAOVIEN();
        public ActionResult Index()
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                var giaovien = dao.GetbyID((int)(Session[Common.CommonConstant.ID_SESSION]));
                return View(giaovien);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult Update( TEACHER tEACHER)
        {
           if(dao.Update(tEACHER))
            {
                TempData["msg"] = "<script>alert('Sửa thông tin thành công');</script>";
                return RedirectToAction("Index", "thongtin");
            }
           else
            {
                TempData["msg"] = "<script>alert('Sửa thông tin không thành công');</script>";
                return RedirectToAction("Index", "thongtin");
            }

//        }
       
//    }
//}