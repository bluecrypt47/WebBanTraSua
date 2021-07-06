using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Introduce
        public ActionResult ListAbout(string searchAbout, int page = 1, int pageSize = 10)
        {
            var dao = new AboutDAO();
            var model = dao.ListAllPaging(searchAbout, page, pageSize);
            ViewBag.searchAbout = searchAbout;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDAO();

                long id = dao.insert(gioiThieu);
                if (id > 0)
                {
                    SetAlert("Thêm Giới thiệu thành công!!!", "success");
                    return RedirectToAction("ListAbout", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Giới thiệu thất bại!!!");
                }
            }
            return View("ListAbout");
        }

        public ActionResult Edit(int id)
        {
            var gioiThieu = new AboutDAO().GetByID(id);
            return View(gioiThieu);
        }

        [HttpPost]
        public ActionResult Edit(GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDAO();

                var result = dao.edit(gioiThieu);

                if (result)
                {
                    SetAlert("Cập nhật Giới thiệu thành công!!!", "success");
                    return RedirectToAction("ListAbout", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Giới thiệu thất bại!!!");
                }
            }
            return View("ListAbout");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AboutDAO().Delete(id);

            return RedirectToAction("ListAbout", "About");
        }
    }
}