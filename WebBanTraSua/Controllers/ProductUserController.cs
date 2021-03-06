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

        public JsonResult ListName(string nameProduct)
        {
            var data = new SanPhamDAO().ListName(nameProduct);

            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchProduct(string searchNameProduct, int page = 1, int pageSize = 12)
        {
            var searchProducts = new SanPhamDAO().Search(searchNameProduct, page, pageSize);
            ViewBag.searchNameProduct = searchNameProduct;
            return View(searchProducts);
        }
    }
}