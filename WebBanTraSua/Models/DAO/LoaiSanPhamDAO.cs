using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class LoaiSanPhamDAO
    {
        WTSDBContext db = null;

        public LoaiSanPhamDAO()
        {
            db = new WTSDBContext();
        }

        // Lấy danh sách
        public List<LoaiSanPham> ListTypeProducts()
        {
            return db.LoaiSanPhams.OrderBy(x => x.ngayTao).ToList();
        }

        // Hiện danh sách có phân trang
        public IEnumerable<LoaiSanPham> ListAllPaging(string searchTypeProducts, int page, int pageSize)
        {
            IQueryable<LoaiSanPham> model = db.LoaiSanPhams;

            if (!string.IsNullOrEmpty(searchTypeProducts))
            {
                model = model.Where(x => x.tenLoaiSanPham.Contains(searchTypeProducts));
            }

            return model.OrderByDescending(x => x.ngayTao).ToPagedList(page, pageSize);
        }

        // Thêm
        public long insert(LoaiSanPham enity)
        {
            db.LoaiSanPhams.Add(enity);
            db.SaveChanges();
            return enity.maLoaiSanPham;
        }

        // Sửa
        public bool edit(LoaiSanPham loaiSanPham)
        {
            try
            {
                var loaiSanPhamEdit = db.LoaiSanPhams.Find(loaiSanPham.maLoaiSanPham);

                loaiSanPhamEdit.maLoaiSanPham = loaiSanPham.maLoaiSanPham;
                loaiSanPhamEdit.tenLoaiSanPham = loaiSanPham.tenLoaiSanPham;
                loaiSanPhamEdit.ngayCapNhat = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Tìm ID
        public LoaiSanPham GetByID(long id)
        {
            return db.LoaiSanPhams.Find(id);
        }

        // Xóa
        public bool Delete(long id)
        {
            try
            {
                var loaiSanPhamDelete = db.LoaiSanPhams.Find(id);
                db.LoaiSanPhams.Remove(loaiSanPhamDelete);
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