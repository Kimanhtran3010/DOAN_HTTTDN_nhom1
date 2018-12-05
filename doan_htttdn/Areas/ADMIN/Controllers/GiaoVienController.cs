using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: ADMIN/GiaoVien
        QL_SCN db = new QL_SCN();
        public ActionResult GiaoVien()
        {
            var dsGv = db.TEACHERs.ToList();
            return View(dsGv);
        }
    }
}