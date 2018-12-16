using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.Areas.ADMIN.Models;
using doan_htttdn.Areas.GIAOVIEN.Models;
using doan_htttdn.DAO.ADMIN;

using PagedList;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class Teaching_classController : Controller
    {
        // GET: ADMIN/Teaching_class
        DAO_Teaching_class dao = new DAO_Teaching_class();
        public ActionResult Index(int? page)
        {
            SetViewBagLop();
            SetViewBagSesssion();
            var list = dao.GetAll();
            //return View(list);
            int pagesize = 15;
            int pagenumber = (page ?? 1);
            return View(list.ToPagedList(pagenumber, pagesize));

        }
        public void SetViewBagLop()
        {
            var list = dao.GetAllClass();
            ViewBag.lop = new SelectList(list.ToList(), "IDClass", "NameClass");
        }
        public List<GIAOVIEN.Models.Month> Create_Month()
        {
            List<Month> months = new List<Month>();
            for (int i = 1; i <= 12; i++)
            {
                Month month = new Month();
                month.ID = i;
                month.Name = "Tháng " + i.ToString();
                months.Add(month);
            }
            return months;
        }
        private void SetViewBagSesssion() // session
        {
            ViewBag.session = new SelectList(Create_Month(), "ID", "ID");
        }
        private void SetViewBagMonth() // session
        {
            ViewBag.month = new SelectList(Create_Month(), "ID", "ID");
        }
        public ActionResult Search(int lop,  DateTime? day , int ?page)
        {
                if (day != null)
                {
                    var model = dao.GetbyDAyAndIDClass((DateTime)day, lop);
                SetViewBagLop();
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View("Index",model.ToPagedList(pagenumber, pagesize));
               // return View("Index", model);
                }
                else
                {
                    var model = dao.GetbyIDClass(lop);
                SetViewBagLop();
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View("Index", model.ToPagedList(pagenumber, pagesize));
                //return View("Index", model);
            }
            
        }
    }
}