﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InsuranceSecure
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Insurance",
               url: "home/Insurance/{type}",
               defaults: new { controller = "Home", action = "Insurance" }
            );

            routes.MapRoute(
               name: "Agents User View",
               url: "Agents/All",
               defaults: new { controller = "Agents", action = "Agents" }
           );
        }
    }
}
