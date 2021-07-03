using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Slide
        public ActionResult ListSlides(string searchProducts, int page = 1, int pageSize = 10)
        {
            var dao = new SlideDAO();
            var model = dao.ListAllPaging(searchProducts, page, pageSize);
            ViewBag.searchProducts = searchProducts;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slide slide)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();

                long id = dao.insert(slide);
                if (id > 0)
                {
                    SetAlert("Thêm Slide thành công!!!", "success");
                    return RedirectToAction("ListSlides", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Slide thất bại!!!");
                }
            }
            return View("ListSlides");
        }

        public ActionResult Edit(long id)
        {
            var slide = new SlideDAO().GetByID(id);
            return View(slide);
        }

        [HttpPost]
        public ActionResult Edit(Slide slide)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();

                var result = dao.edit(slide);

                if (result)
                {
                    SetAlert("Cập nhật Slide thành công!!!", "success");
                    return RedirectToAction("ListSlides", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Silde thất bại!!!");
                }
            }
            return View("ListSlides");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new SlideDAO().Delete(id);

            return RedirectToAction("ListSlides", "Slide");
        }
    }
}