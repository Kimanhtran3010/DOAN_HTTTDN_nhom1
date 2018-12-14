using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.USER.Controllers
{
    public class XemDonHangController : Controller
    {
        QL_SCN db = new QL_SCN();
        // GET: USER/XemDonHang
        public ActionResult Index(string timkiem="duc222s@yahoo.com")
        {

            var list = db.ORDERS.Where(x => x.Email == timkiem).ToList();

            //var query = (from a in db.ORDERS
            //            join b in db.DETAIL_ORDERS on a.IDOrders equals b.IDOrders
            //            join c in db.PRODUCT on b.IDRobot equals c.IDRobot
            //            where a.Email == timkiem
            //            select new doan_htttdn.Areas.USER.Models.ViewDonHang()
            //            {
            //                ID_Order= a.IDOrders,NameCustomer= a.NameCustomer,ADDRESS= a.ADDRESS,DATE= a.DATE,Phone= a.Phone,Payment= a.Payment,NumberProduct=a.NumberProduct,PriceTotal=a.PriceTotal,
            //                Number= b.Number, Price=b.Price,
            //                 IDRobot=c.IDRobot, Image=c.Image, Name= c.Name,                           
            //            }).ToList();
            return View(list);
        }
        public ActionResult ViewDetail(int id)
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
    }
}