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
        

        public ActionResult ListNews_SP()
        {
            var model = db.PRODUCTs.Where(x => x.IDRobot != null).ToList();
            return View(model);
        }
        public ActionResult ListNews_Course()
        {
            var model = db.COURSEs.Where(x => x.IDCourse != null).ToList();
            return View(model);
        }

        

    }


}