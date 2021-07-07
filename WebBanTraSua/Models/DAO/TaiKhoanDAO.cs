using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class TaiKhoanDAO
    {
        WTSDBContext db = null;
        public TaiKhoanDAO()
        {
            db = new WTSDBContext();
        }

        // Thêm
        public long insert(TaiKhoan enity)
        {
            db.TaiKhoans.Add(enity);
            db.SaveChanges();
            return enity.id;
        }

        // Sửa
        public bool edit(TaiKhoan taiKhoan)
        {
            try
            {
                var user = db.TaiKhoans.Find(taiKhoan.id);

                user.email = taiKhoan.email;
                if (!string.IsNullOrEmpty(taiKhoan.matKhau))
                {
                    user.matKhau = taiKhoan.matKhau;
                }
                user.maLoaiTaiKhoan = taiKhoan.maLoaiTaiKhoan;
                user.tenNguoiDung = taiKhoan.tenNguoiDung;
                user.diaChi = taiKhoan.diaChi;
                user.sdt = taiKhoan.sdt;
                user.ngayCapNhat = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Hiện danh sách có phân trang user
        public IEnumerable<TaiKhoan> ListAllPaging(string searchUser, int page, int pageSize)
        {
            IQueryable<TaiKhoan> model = db.TaiKhoans.Where(x => x.maLoaiTaiKhoan == false);

            if (!string.IsNullOrEmpty(searchUser))
            {
                model = model.Where(x => x.email.Contains(searchUser) || x.tenNguoiDung.Contains(searchUser));
            }

            return model.OrderByDescending(x => x.ngayTao).ToPagedList(page, pageSize);
        }

        // Hiện danh sách có phân trang admin
        public IEnumerable<TaiKhoan> ListAllPagingAdmin(string searchAdmin, int page, int pageSize)
        {
            IQueryable<TaiKhoan> model = db.TaiKhoans.Where(x => x.maLoaiTaiKhoan == true);

            if (!string.IsNullOrEmpty(searchAdmin))
            {
                model = model.Where(x => x.email.Contains(searchAdmin) || x.tenNguoiDung.Contains(searchAdmin));
            }

            return model.OrderByDescending(x => x.ngayTao).ToPagedList(page, pageSize);
        }

        // Tìm theo Email
        public TaiKhoan getByEmail(string email)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.email == email);
        }

        // Tìm theo ID
        public TaiKhoan GetByID(long id)
        {
            return db.TaiKhoans.Find(id);
        }

        // Đăng nhập
        public bool Login(string email, string password)
        {
            object[] sqlParam =
            {
                new SqlParameter("@email", email),
                new SqlParameter("@matkhau", password)
            };

            //var result = db.Database.SqlQuery<bool>("login @email, @matkhau", sqlParam).SingleOrDefault();

            var result = db.TaiKhoans.Count(x => x.email == email && x.matKhau == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Xóa
        public bool Delete(long id)
        {
            try
            {
                var user = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckEmail(string email)
        {
            return db.TaiKhoans.Count(x => x.email == email) > 0;
        }
    }
}