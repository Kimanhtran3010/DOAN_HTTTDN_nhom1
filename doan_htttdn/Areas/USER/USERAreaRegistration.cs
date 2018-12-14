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
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "Product_RoBo",
               "USER/san-pham",
               new { controller = "RoBo", action = "Index", id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Home Index",
               "USER/trang-chu",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional }
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
               "Cart Delete",
               "USER/gio-hang/delete",
               new { controller = "Cart", action = "Delete", id = UrlParameter.Optional }
           );
            context.MapRoute(
              "Cart Payment",
              "USER/gio-hang/thanh-toan",
              new { controller = "Cart", action = "ThanhToan", id = UrlParameter.Optional }
          );
            context.MapRoute(
              "Confirm",
              "USER/gio-hang/xac-nhan",
              new { controller = "Cart", action = "ConfirmEmail", id = UrlParameter.Optional }
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