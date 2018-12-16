using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace doan_htttdn
{
    public class RouteConfig2
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Detail",
            //    url: "chi-tiet/{id}",
            //    defaults: new { controller = "TinTuc", action = "Detail", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional }
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

