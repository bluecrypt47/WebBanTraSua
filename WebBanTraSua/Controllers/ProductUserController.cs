using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Models.DAO;
using PagedList;
using PagedList.Mvc;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class ProductUserController : Controller
    {
        // GET: ProductUser
        public ActionResult AllProducts(int page= 1, int pageSize = 12)
        {
            var allProducts = new SanPhamDAO();
            var model = allProducts.AllProducts(page, pageSize);
            return View(model);
        }

        public ActionResult TypeProducts(long idTypeProduct, int page = 1, int pageSize = 9)
        {
            var typeProducts = new SanPhamDAO().ListProductsByTypeID(idTypeProduct, page, pageSize);

            ViewBag.typeProducts = typeProducts;
            ViewBag.Categorys = new LoaiSanPhamDAO().ListTypeProducts();
            return View(typeProducts);
        }

        public ActionResult ProductDetails(long idProduct)
        {
            var typeProducts = new SanPhamDAO().GetByID(idProduct);

            ViewBag.ListProductsRelated = new SanPhamDAO().ListProductsRelated(idProduct);
            ViewBag.Categorys = new LoaiSanPhamDAO().ListTypeProducts();
            return View(typeProducts);
        }

        public ActionResult HistoryBuy(long idUser)
        {
            var user = new TaiKhoanDAO().GetByID(idUser);
            var dao = new HoaDonDAO();

            List<HoaDon> HistoryBuy = dao.HistoryBuy(user.email);

            return View(HistoryBuy);
        }
    }
}