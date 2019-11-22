using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace News
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            routes.MapRoute("getProduct", "{type}/{meta}",
            new { controller = "Category", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                {"type","khoa"}
            },
            namespaces: new[] { "News.Controllers" } );

            routes.MapRoute("getDetail", "{type}/{meta}/{id}",
            new { controller = "Category", action = "getDetail", id = UrlParameter.Optional },
            new RouteValueDictionary
            {
                {"type","tin-tuc"}
            },
            namespaces: new[] { "News.Controllers" });

            routes.MapRoute("Home", "{type}/{meta}",
            new { controller = "Home", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                {"type","trang-chu"}
            },
            namespaces: new[] { "News.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"News.Controllers"}
            );
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
