using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarketPlace
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapMvcAttributeRoutes();*/

            routes.MapRoute(
            name: "Login",
            url: "Login",
            defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
        );


            routes.MapRoute(
               name: "SeachDetails",
               url: "{controller}/{action}/{ProductName}",
               defaults: new { controller = "Search", action = "GetProducts" }
           );

            routes.MapRoute(
              name: "Search",
              url: "{controller}/{action}/{ProductName}",
              defaults: new { controller = "Search", action = "GetProductsJson" }
          );

            routes.MapRoute(
               "SearchItem", //this is just a name of the route
               "Search/Search/{searchitem}", //go this this path when url is in this format
                new { controller = "Search", action = "Search", searchitem = UrlParameter.Optional }
         );

            routes.MapRoute(
             "ProductDetails", //this is just a name of the route
             "Products/GetProductProductDetailJson/{pid}", //go this this path when url is in this format
              new { controller = "Products", action = "GetProductProductDetailJson", pid = UrlParameter.Optional }
       );







            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
