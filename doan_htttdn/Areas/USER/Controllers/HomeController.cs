using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace doan_htttdn.Areas.USER.Controllers
{
    public class HomeController : Controller
    {
        doan_htttdn.FF.QL_SCN db = new FF.QL_SCN();
        // GET: USER/Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Header_Cart()
        {
            var cart = Session[Common.CommonConstant.CartSession];
            var list = (List<USER.Models.Cart_items>)cart;
            if (cart != null)
            {
                list = (List<USER.Models.Cart_items>)cart;
            }
            return PartialView(list);
        }
        public ActionResult SanPham()
        {
            ViewData["Top3"] = db.PRODUCTs.Take(3).ToList();
            return PartialView();
        }

    }


}