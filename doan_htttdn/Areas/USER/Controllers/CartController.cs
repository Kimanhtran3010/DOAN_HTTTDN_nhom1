using doan_htttdn.Areas.USER.Models;
using doan_htttdn.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using doan_htttdn.Common;
using System.Data.Entity.Validation;
using System.Net.Mail;
using System.Net;

namespace doan_htttdn.Areas.USER.Controllers
{
    public class CartController : Controller
    {
        // GET: USER/Cart
        // private string CartSession = "CartSession";
        // GET: USER/Cart
        private FF.QL_SCN db = new FF.QL_SCN();
        DAO_Cart dc = new DAO_Cart();
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<Cart_items>();
            if (cart != null)
            {
                list = (List<Cart_items>)cart;
            }
            return View(list);
        }
        
        public ActionResult AddItems(string product_id, int number)
        {
            var ProDuct = new DAO_Product().ViewDetail(product_id);
            var Cart = Session[CommonConstant.CartSession];
            List<Cart_items> ListCart = new List<Cart_items>();
            if (Cart != null)
                ListCart = (List<Cart_items>)Cart;
            if (ListCart.Any(a => a.product.IDRobot == product_id))
            {
                ListCart.Single(a => a.product.IDRobot == product_id).Quantity++;
            }
            else
            {
                ListCart.Add(new Cart_items() { product = new DAO_Product().ViewDetail(product_id), Quantity = number });
            }

            Session[CommonConstant.CartSession] = ListCart;

            return RedirectToAction("Index");          
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<doan_htttdn.Areas.USER.Models.Cart_items>>(cartModel);
            var sessionItem = (List<Cart_items>)Session[CommonConstant.CartSession];

            foreach (var item in sessionItem)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.IDRobot == item.product.IDRobot);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            return Json(new
            {
                stastus = true
            });
        }
        public JsonResult Delete(string id)
        {
            var sessionCart = (List<USER.Models.Cart_items>)Session[CommonConstant.CartSession];
            sessionCart.RemoveAll(x => x.product.IDRobot == id);
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<Cart_items>();
            if (cart != null)
            {
                list = (List<Cart_items>)cart;
            }
            return View(list);
            
        }
        long tien;
        int count;

        [HttpPost]
        public ActionResult ThanhToan(string txt_hoten , 
            string txt_sdt , string txt_email , string txt_diachi , 
            string txt_ghichu , string txt_tt , string txt_km = "FCL000000")
        {
            int id;
            var cart = (List<Cart_items>)Session[CommonConstant.CartSession];
            FF.ORDER od = new FF.ORDER();
            
            try
            {

               
                foreach (var item in cart)
                {
                    tien = (int)item.product.Price * item.Quantity;
                    count += 1;
                }

                // long tong = tien * id.Value;
                
                od.NameCustomer = txt_hoten;
                od.Phone = txt_sdt;
                od.ADDRESS = txt_diachi;
                od.Email = txt_email;
                od.NumberProduct = count;
                od.IDPromotion = txt_km;
                od.PriceTotal = tien;
                od.DATE = DateTime.Today;
                od.Payment = txt_tt;
                od.Note = txt_ghichu;
                od.State = 0;
                od.Verify = false;
                id = dc.get_id(od);
                string url = "http://localhost:51852/USER/gio-hang/xac-nhan?ID=" + id;
                dc.sendmail("Xác nhận đơn hàng", url, od.Email);
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings. 
                var errorMessages = ex.EntityValidationErrors
                  .SelectMany(x => x.ValidationErrors)
                  .Select(x => x.ErrorMessage);

                // Join the list to a single string. 
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one. 
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message. 
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            try
            {

                foreach (var item in cart)
                {
                    FF.DETAIL_ORDERS d_od = new FF.DETAIL_ORDERS();
                    d_od.IDOrders = id;
                    d_od.IDRobot = item.product.IDRobot;
                    d_od.Number = item.Quantity;
                    d_od.Price = item.product.Price;
                    db.DETAIL_ORDERS.Add(d_od);
                    db.SaveChanges();

                    DAO_Product dp = new DAO_Product();
                    var sp = dp.ViewDetail(item.product.IDRobot);
                    sp.Number = sp.Number - item.Quantity;
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { throw; }
            Session[CommonConstant.CartSession] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ConfirmEmail (int ID)
        {
            try
            {
                var or = db.ORDERS.Where(x => x.IDOrders == ID).SingleOrDefault();
                or.Verify = true;
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings. 
                var errorMessages = ex.EntityValidationErrors
                  .SelectMany(x => x.ValidationErrors)
                  .Select(x => x.ErrorMessage);

                // Join the list to a single string. 
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one. 
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message. 
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}