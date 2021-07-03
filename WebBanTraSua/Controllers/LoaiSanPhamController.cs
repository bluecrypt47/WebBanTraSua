using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class LoaiSanPhamController : BaseController
    {
        // GET: LoaiSanPham
        public ActionResult ListTypeProucts(string searchTypeProducts, int page = 1, int pageSize = 10)
        {
            var dao = new LoaiSanPhamDAO();
            var model = dao.ListAllPaging(searchTypeProducts, page, pageSize);
            ViewBag.searchProducts = searchTypeProducts;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiSanPhamDAO();

                long id = dao.insert(loaiSanPham);
                if (id > 0)
                {
                    SetAlert("Thêm Loại sản phẩm thành công!!!", "success");
                    return RedirectToAction("ListTypeProucts", "LoaiSanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Loại sản phẩm thất bại!!!");
                }
            }
            return View("ListTypeProucts");
        }

        public ActionResult Edit(long id)
        {
            var loaiSanPham = new LoaiSanPhamDAO().GetByID(id);
            return View(loaiSanPham);
        }

        [HttpPost]
        public ActionResult Edit(LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiSanPhamDAO();

                var result = dao.edit(loaiSanPham);

                if (result)
                {
                    SetAlert("Cập nhật Loại sản phẩm thành công!!!", "success");
                    return RedirectToAction("ListTypeProucts", "LoaiSanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Loại sản phẩm thất bại!!!");
                }
            }
            return View("ListTypeProucts");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new LoaiSanPhamDAO().Delete(id);

            SetAlert("Xóa Loại sản phẩm thành công!!!", "success");
            return RedirectToAction("ListTypeProucts", "LoaiSanPham");
        }
    }
}