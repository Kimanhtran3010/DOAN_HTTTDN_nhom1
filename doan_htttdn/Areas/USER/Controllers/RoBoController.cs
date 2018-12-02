using doan_htttdn.DAO;
using doan_htttdn.FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doan_htttdn.Areas.USER.Controllers
{
    public class RoBoController : Controller
    {
        //có mà. với tui mlowis đổi cái chuỗi kết nối QL_SCN
        // GET: USER/RoBoK
        private QL_SCN db = new QL_SCN();
        DAO_Product dp = new DAO_Product();

        public ActionResult Index(int page = 2, int pagesize = 6)
        {
            var list = dp.listpd(page, pagesize);
            return View(list);
        }

        public ActionResult Detail(string ID)
        {
            var product = dp.ViewDetail(ID);
            return View(product);
        }
    }
}