using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanTraSua
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "ProductUser", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "ProductUser", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "AddCart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "All Products",
                url: "tat-ca-san-pham",
                defaults: new { controller = "ProductUser", action = "AllProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product Details",
                url: "chi-tiet-san-pham/{idProduct}",
                defaults: new { controller = "ProductUser", action = "ProductDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Type Product",
                url: "loai-san-pham/{idTypeProduct}",
                defaults: new { controller = "ProductUser", action = "TypeProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
