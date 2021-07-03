using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Controllers
{
    public class IntroduceController : BaseController
    {
        // GET: Introduce
        public ActionResult ListIntroduce(string searchIntroduce, int page = 1, int pageSize = 10)
        {
            var dao = new IntroduceDAO();
            var model = dao.ListAllPaging(searchIntroduce, page, pageSize);
            ViewBag.searchIntroduce = searchIntroduce;
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
                var dao = new IntroduceDAO();

                long id = dao.insert(gioiThieu);
                if (id > 0)
                {
                    SetAlert("Thêm Giới thiệu thành công!!!", "success");
                    return RedirectToAction("ListIntroduce", "Introduce");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Giới thiệu thất bại!!!");
                }
            }
            return View("ListIntroduce");
        }

        public ActionResult Edit(int id)
        {
            var gioiThieu = new IntroduceDAO().GetByID(id);
            return View(gioiThieu);
        }

        [HttpPost]
        public ActionResult Edit(GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                var dao = new IntroduceDAO();

                var result = dao.edit(gioiThieu);

                if (result)
                {
                    SetAlert("Cập nhật Giới thiệu thành công!!!", "success");
                    return RedirectToAction("ListIntroduce", "Introduce");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Giới thiệu thất bại!!!");
                }
            }
            return View("ListIntroduce");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new SlideDAO().Delete(id);

            return RedirectToAction("ListIntroduce", "Introduce");
        }
    }
}