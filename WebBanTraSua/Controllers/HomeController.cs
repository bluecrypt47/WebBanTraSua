using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Common;
using WebBanTraSua.Models;
using WebBanTraSua.Models.DAO;

namespace WebBanTraSua.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categorys = new LoaiSanPhamDAO().ListTypeProducts();
            ViewBag.Slides = new SlideDAO().ListSlides();
            ViewBag.SlidesNewProducts = new SanPhamDAO().SlideListSanPhamMoi();
            ViewBag.HighlightProducts = new SanPhamDAO().ListSanPhamNoiBat();
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menus()
        {
            var model = new MenuDAO().listMenus();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = Session[CommenConstants.CartSession];
            var listItem = new List<CartModel>();
            if (cart != null)
            {
                listItem = (List<CartModel>)cart;
            }
            return PartialView(listItem);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}