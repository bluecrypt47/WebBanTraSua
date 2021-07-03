using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Models.DAO;

namespace WebBanTraSua.Controllers
{
    public class ProductUserController : Controller
    {
        // GET: ProductUser
        public ActionResult AllProducts()
        {
            var allProducts = new SanPhamDAO();
            var model = allProducts.AllProducts();
            return View(model);
        }

        public ActionResult TypeProducts(long idTypeProduct)
        {
            var typeProducts = new SanPhamDAO().ListProductsByTypeID(idTypeProduct);

            ViewBag.typeProducts = typeProducts;
            ViewBag.Categorys = new LoaiSanPhamDAO().ListTypeProducts();
            return View(typeProducts);
        }
        //public ActionResult TypeProducts(long idTypeProduct, int pageIndex = 1, int pageSize = 10)
        //{
        //    int totalRecord = 0;
        //    var typeProducts = new SanPhamDAO().ListProductsByTypeID(idTypeProduct, ref totalRecord, pageIndex, pageSize);

        //    ViewBag.Total = totalRecord;
        //    ViewBag.Page = pageIndex;

        //    int maxPage = 5;
        //    int totalPage = 0;

        //    totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));

        //    ViewBag.TotalPage = totalPage;
        //    ViewBag.MaxPage = maxPage;
        //    ViewBag.First = 1;
        //    ViewBag.Last = totalPage;
        //    ViewBag.Next = pageIndex + 1;
        //    ViewBag.Prev = pageIndex - 1;

        //    ViewBag.typeProducts = typeProducts;
        //    ViewBag.Categorys = new LoaiSanPhamDAO().ListTypeProducts();
        //    return View(typeProducts);
        //}

        public ActionResult ProductDetails(long idProduct)
        {
            var typeProducts = new SanPhamDAO().GetByID(idProduct);

            ViewBag.ListProductsRelated = new SanPhamDAO().ListProductsRelated(idProduct);
            ViewBag.Categorys = new LoaiSanPhamDAO().ListTypeProducts();
            return View(typeProducts);
        }
    }
}