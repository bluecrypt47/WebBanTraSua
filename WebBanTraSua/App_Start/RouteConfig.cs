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
                name: "LoginUser",
                url: "dang-nhap",
                defaults: new { controller = "LoginUser", action = "LoginUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "LoginUser", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Checkout",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
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
