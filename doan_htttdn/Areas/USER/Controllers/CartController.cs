//using doan_htttdn.Areas.USER.Models;
//using doan_htttdn.DAO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Script.Serialization;

//namespace doan_htttdn.Areas.USER.Controllers
//{
//    public class CartController : Controller
//    {
//        // GET: USER/Cart
//        private string CartSession = "CartSession";
//        // GET: USER/Cart
//        public ActionResult Index()
//        {
//            var cart = Session[CartSession];
//            var list = new List<Cart_items>();
//            if (cart != null)
//            {
//                list = (List<Cart_items>)cart;
//            }
//            return View(list);
//        }
        
//        public ActionResult AddItems(string product_id, int number)
//        {
//            var ProDuct = new DAO_Product().ViewDetail(product_id);
//            var cart = Session[CartSession];
//            if (cart != null)
//            {
//                var list = new List<Cart_items>();
//                if (list.Exists(x => x.product.IDRobot == product_id))
//                {
//                    foreach (var item in list)
//                    {
//                        if (item.product.IDRobot == product_id)
//                        {
//                            item.Quantity += number;
//                        }
//                    }
//                }
//                else
//                {
//                    var item = new Cart_items();
//                    item.product = ProDuct;
//                    item.Quantity = number;
//                    list.Add(item);

//                    // gán vào session
//                    Session[CartSession] = list;
//                }
//            }
//            else
//            {
//                // tạo mới đối tượng cart item
//                var item = new Cart_items();
//                item.product = ProDuct;
//                item.Quantity = number;
//                var list = new List<Cart_items>();
//                list.Add(item);
//                // gán vào session
//                Session[CartSession] = list;

//            }
//            return RedirectToAction("Index");
//        }
//        public JsonResult Update(string cartModel)
//        {
//            var jsonCart = new JavaScriptSerializer().Deserialize<List<doan_htttdn.Areas.USER.Models.Cart_items>>(cartModel);
//            var sessionItem = (List<Cart_items>)Session[CartSession];

//            foreach (var item in sessionItem)
//            {
//                var jsonItem = jsonCart.SingleOrDefault(x => x.product.IDRobot == item.product.IDRobot);
//                if (jsonItem != null)
//                {
//                    item.Quantity = jsonItem.Quantity;
//                }
//            }
//            return Json(new
//            {
//                stastus = true
//            });
//        }
//    }
//}