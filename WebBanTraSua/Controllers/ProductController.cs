using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult ListProucts(string searchProducts, int page = 1, int pageSize = 10)
        {
            var dao = new SanPhamDAO();
            var model = dao.ListAllPaging(searchProducts, page, pageSize);
            ViewBag.searchProducts = searchProducts;
            return View(model);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new LoaiSanPhamDAO();
            ViewBag.MaLoaiSanPham = new SelectList(dao.ListTypeProducts(), "maLoaiSanPham", "tenLoaiSanPham", selectedId);
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDAO();

                long id = dao.insert(sanPham);
                if (id > 0)
                {
                    SetAlert("Thêm Sản phẩm thành công!!!", "success");
                    return RedirectToAction("ListProucts", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Sản phẩm thất bại!!!");
                }
            }
            return View("ListProucts");
        }

        public ActionResult Edit(long id)
        {
            var sanPham = new SanPhamDAO().GetByID(id);
            SetViewBag();
            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDAO();

                var result = dao.edit(sanPham);

                if (result)
                {
                    SetAlert("Cập nhật Sản phẩm thành công!!!", "success");
                    return RedirectToAction("ListProucts", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Sản phẩm thất bại!!!");
                }
            }
            return View("ListProucts");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new SanPhamDAO().Delete(id);

            SetAlert("Xóa Sản phẩm thành công!!!", "success");
            return RedirectToAction("ListProucts", "Product");
        }
    }
}