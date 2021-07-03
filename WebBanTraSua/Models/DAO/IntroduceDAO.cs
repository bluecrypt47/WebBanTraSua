using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class IntroduceDAO
    {
        WTSDBContext db = null;
        public IntroduceDAO()
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

        public IEnumerable<GioiThieu> ListAllPaging(string searchIntroduce, int page, int pageSize)
        {
            IQueryable<GioiThieu> model = db.GioiThieux;

            if (!string.IsNullOrEmpty(searchIntroduce))
            {
                model = model.Where(x => x.noiDung.Contains(searchIntroduce));
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