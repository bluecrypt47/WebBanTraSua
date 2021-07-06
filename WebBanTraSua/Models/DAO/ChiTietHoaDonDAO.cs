using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class ChiTietHoaDonDAO
    {
        WTSDBContext db = null;

        public ChiTietHoaDonDAO()
        {
            db = new WTSDBContext();
        }

        public bool InsertBill(ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ChiTietHoaDon> GetByIDBill(long idBill)
        {
            ChiTietHoaDon listBill = new ChiTietHoaDon();

            IQueryable<ChiTietHoaDon> model = db.ChiTietHoaDons.Where(x => x.maHoaDon == idBill);

            return model;
        }
    }
}