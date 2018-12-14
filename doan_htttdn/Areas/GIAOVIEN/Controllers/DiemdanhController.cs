//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using doan_htttdn.DAO.GIAOVIEN;

//namespace doan_htttdn.Areas.GIAOVIEN.Controllers
//{
//    public class DiemdanhController : Controller
//    {

//        // GET: GIAOVIEN/Diemdanh
//        DAO_Hocvien dao = new DAO_Hocvien();
//        public ActionResult Index()
//        {
            
//            if (Session[Common.CommonConstant.USER_SESSION] != null)
//            {
//                var a = dao.GetALL();
//                return View(a);
//            }
//            else
//            {
//                return RedirectToAction("Index", "Login");
//            }
//        }

//    }
//}