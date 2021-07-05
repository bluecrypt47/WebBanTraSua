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
    public class BillController : BaseController
    {
        // GET: Bill
        public ActionResult ListBill(string searchBill, int page = 1, int pageSize = 10)
        {
            var dao = new HoaDonDAO();
            var model = dao.ListAllPaging(searchBill, page, pageSize);
            ViewBag.searchBill = searchBill;
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new HoaDonDAO().Delete(id);

            SetAlert("Xóa Hóa đơn thành công!!!", "success");
            return RedirectToAction("ListBill", "Bill");
        }
    }
}