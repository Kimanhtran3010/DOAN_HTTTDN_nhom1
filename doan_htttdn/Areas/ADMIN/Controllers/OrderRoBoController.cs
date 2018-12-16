using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO;
using PagedList;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class OrderRoBoController : Controller
    {
        private QL_SCN db = new QL_SCN();
        DAO_Cart dod = new DAO_Cart();
        ORDER d_od = new ORDER();
        private object list1;
        // GET: ADMIN/Order
        public ActionResult Index(string tk , Nullable<DateTime> nkq , int? Page )
        {
            
            
            if (tk == null && nkq == null)
            {
                list1 = dod.listod(Page ?? 1 , 6);
            }
            else if(nkq == null)
            {
                list1 = dod.search(tk, Page ?? 1, 5);
            }
            else
            { 
            list1 = dod.search_date(nkq, Page ?? 1, 10);
            }
            return View(list1);
        }

        // GET: ADMIN/Order/Details/5
        public ActionResult Details(int id)
        {
            var query = (from a in db.DETAIL_ORDERS
                         join b in db.PRODUCTs on a.IDRobot equals b.IDRobot
                         where a.IDOrders == id
                         select new doan_htttdn.Areas.USER.Models.ViewDonHang()
                         {
                             Number = a.Number,
                             Price = a.Price,
                             IDRobot = a.IDRobot,
                             Image = b.Image,
                             Name = b.Name,
                             Contents = b.Contents,
                         }).ToList();
            return View(query);
        }
    

        // GET: ADMIN/Order/Create
        public ActionResult Huy(int id)
        {
            var od = db.ORDERS.SingleOrDefault(x => x.IDOrders == id);
            od.State = 0;
            db.SaveChanges();
            List<DETAIL_ORDERS> dod = db.DETAIL_ORDERS.Where(x => x.IDOrders == od.IDOrders).ToList();
            foreach (var item in dod)
            {
                var pd = db.PRODUCTs.SingleOrDefault(x => x.IDRobot == item.IDRobot);

                pd.Number = pd.Number + item.Number;
                db.SaveChanges();
            }
            
 
            return RedirectToAction("Index", "OrderRoBo");
        }

        // POST: ADMIN/Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/Order/Edit/5
        public ActionResult Edit(int id)
        {
            var od = db.ORDERS.SingleOrDefault(x => x.IDOrders == id);
            if(od.State <4)
            {
                od.State += 1;
            db.SaveChanges();
            }
                return RedirectToAction("Index", "OrderRoBo");
        }

        // POST: ADMIN/Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ADMIN/Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
