using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTraSua.Common;
using WebBanTraSua.Models;
using WebBanTraSua.Models.DAO;
using WebBanTraSua.Models.EF;

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

        public ActionResult DetailsBill(long id)
        {
            var dao = new ChiTietHoaDonDAO();
            var model = dao.GetByIDBill(id);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new HoaDonDAO().Delete(id);

            SetAlert("Xóa Hóa đơn thành công!!!", "success");
            return RedirectToAction("ListBill", "Bill");
        }

        public ActionResult HistoryBuy(long idUser)
        {
            var user = new TaiKhoanDAO().GetByID(idUser);
            var dao = new HoaDonDAO();

            List<HoaDon> HistoryBuy = dao.HistoryBuy(user.email);

            return View(HistoryBuy);
        }

        public ActionResult DetailHistoryBuy(long idBill)
        {
            var dao = new ChiTietHoaDonDAO();
            var model = dao.GetByIDBill(idBill);
            return View(model);
        }
    }
}