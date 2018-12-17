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
        private object list;

        public ActionResult Index(string txt_search,int page = 1, int pagesize = 9  )
        {
            
            if (txt_search == null)
            {
                list = dp.listpd(page, pagesize);
            }
            else
            {
                list = dp.search(txt_search,1,5);
            }
            return View(list);
        }

        public ActionResult Detail(string ID)
        {

            //List<object> listpd = new List<object>();
            //listpd.Add(dp.ViewDetail(ID));
            //listpd.Add(dp.top3_pd());
            var listpd = dp.ViewDetail(ID);
            return View(listpd);
        }
        [ChildActionOnly]
        public ActionResult Top3_Product()
        {
            ViewData["Top3"] = db.PRODUCTs.Take(3).ToList();
            return PartialView();
        }



    }
}