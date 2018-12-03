using System.Web.Mvc;

namespace doan_htttdn.Areas.GIAOVIEN
{
    public class GIAOVIENAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GIAOVIEN";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GIAOVIEN_default",
                "GIAOVIEN/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}