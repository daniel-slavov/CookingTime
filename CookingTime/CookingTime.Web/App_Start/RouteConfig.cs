﻿using System.Web.Mvc;
using System.Web.Routing;

namespace CookingTime.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "UserDetails",
            //    url: "Profile/Details/{username}",
            //    defaults: new { controller = "Profile", action = "Details" });

            routes.MapRoute(
                name: "Recipe",
                url: "Recipe/{action}/{id}",
                defaults: new { controller = "Recipe", action = "All", id = UrlParameter.Optional },
                namespaces: new[] { "CookingTime.Web.Controllers" }
                );

            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "CookingTime.Web.Controllers" }
             );
        }
    }
}
