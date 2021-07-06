using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class AboutDAO
    {
        WTSDBContext db = null;
        public AboutDAO()
        {
            db = new WTSDBContext();
        }

        // Thêm
        public long insert(GioiThieu enity)
        {
            db.GioiThieux.Add(enity);
            db.SaveChanges();
            return enity.id;
        }

        // Sửa
        public bool edit(GioiThieu gioiThieu)
        {
            try
            {
                var gThieu = db.GioiThieux.Find(gioiThieu.id);

                gThieu.noiDung = gioiThieu.noiDung;
                gThieu.ngayCapNhat = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<GioiThieu> ListAllPaging(string searchAbout, int page, int pageSize)
        {
            IQueryable<GioiThieu> model = db.GioiThieux;

            if (!string.IsNullOrEmpty(searchAbout))
            {
                model = model.Where(x => x.noiDung.Contains(searchAbout));
            }

            return model.OrderByDescending(x => x.ngayCapNhat).ToPagedList(page, pageSize);
        }
        // Tìm ID
        public GioiThieu GetByID(long id)
        {
            return db.GioiThieux.Find(id);
        }

        // Xóa
        public bool Delete(int id)
        {
            try
            {
                var gioiThieu = db.GioiThieux.Find(id);
                db.GioiThieux.Remove(gioiThieu);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}