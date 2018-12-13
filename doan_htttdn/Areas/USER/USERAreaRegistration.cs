using System.Web.Mvc;

namespace doan_htttdn.Areas.USER
{
    public class USERAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "USER";
            }
        }
        // mở bài của tui , thêm mấy cái vào đây , K.A thiểu trang này rồi
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "Product_RoBo",
               "USER/san-pham",
               new { controller = "RoBo", action = "Index", id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Add Cart",
               "USER/them-gio-hang",
               new { controller = "Cart", action = "AddItems", id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Cart",
               "USER/gio-hang",
               new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Cart Update",
               "USER/gio-hang/update",
               new { controller = "Cart", action = "Update", id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Product_Detail",
               "USER/chi-tiet-san-pham",
               new { controller = "RoBo", action = "Detail", id = UrlParameter.Optional }
           );



            context.MapRoute(
                "USER_default",
                "USER/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}