using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace doan_htttdn
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "TinTuc",
            //    url: "TinTuc/chi-tiet/{id}",
            //    defaults: new { controller = "TinTuc", action = "Detail", id = UrlParameter.Optional }
            //    //namespaces : new[] { "doan_htttdn.Areas.USER.Controllers" }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "User/Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User/Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
