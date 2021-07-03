using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class SanPhamDAO
    {
        WTSDBContext db = null;

        public SanPhamDAO()
        {
            db = new WTSDBContext();
        }

        // List all sản phẩm 
        public List<SanPham> AllProducts()
        {

            return db.SanPhams.OrderByDescending(x => x.ngayCapNhat).ToList();
        }


        // List sản phẩm liên quan
        public List<SanPham> ListProductsRelated(long id)
        {
            var product = db.SanPhams.Find(id);
            return db.SanPhams.Where(x => x.maSanPham != id && x.maLoaiSanPham == product.maLoaiSanPham).ToList();
        }

        // List sản phẩm cùng loại
        //public List<SanPham> ListProductsByTypeID(long id, ref int totalRecord, int pageIndex, int pageSize)
        //{
        //    totalRecord = db.SanPhams.Where(x => x.maLoaiSanPham == id).Count();
        //    var model = db.SanPhams.Where(x => x.maLoaiSanPham == id).OrderByDescending(x => x.ngayCapNhat).Skip((pageSize - 1) * pageIndex).Take(pageSize).ToList();
        //    return model;
        //}
        public List<SanPham> ListProductsByTypeID(long id)
        {
            return db.SanPhams.Where(x => x.maLoaiSanPham == id).ToList();
        }

        // List sản phẩm mới
        public List<SanPham> SlideListSanPhamMoi()
        {
            return db.SanPhams.OrderByDescending(x => x.sanPhamMoi == true).Take(12).ToList();
        }

        // List sản phẩm nổi bật
        public List<SanPham> ListSanPhamNoiBat()
        {
            return db.SanPhams.OrderByDescending(x => x.sanPhamNoiBat == true).Take(12).ToList();
        }

        // Hiện danh sách có phân trang
        public IEnumerable<SanPham> ListAllPaging(string searchProducts, int page, int pageSize)
        {
            IQueryable<SanPham> model = db.SanPhams;

            if (!string.IsNullOrEmpty(searchProducts))
            {
                model = model.Where(x => x.tenSanPham.Contains(searchProducts));
            }

            return model.OrderByDescending(x => x.ngayTao).ToPagedList(page, pageSize);
        }


        // Thêm 
        public long insert(SanPham enity)
        {
            db.SanPhams.Add(enity);
            db.SaveChanges();
            return enity.maSanPham;
        }

        // Sửa
        public bool edit(SanPham sanPham)
        {
            try
            {
                var sanPhamEdit = db.SanPhams.Find(sanPham.maSanPham);

                sanPhamEdit.LoaiSanPham = sanPham.LoaiSanPham;
                sanPhamEdit.tenSanPham = sanPham.tenSanPham;
                sanPhamEdit.hinhAnh = sanPham.hinhAnh;
                sanPhamEdit.giaBan = sanPham.giaBan;
                sanPhamEdit.dvt = sanPham.dvt;
                sanPhamEdit.giamGia = sanPham.giamGia;
                sanPhamEdit.gioiThieuSanPham = sanPham.gioiThieuSanPham;
                sanPhamEdit.sanPhamMoi = sanPham.sanPhamMoi;
                sanPhamEdit.sanPhamNoiBat = sanPham.sanPhamNoiBat;
                sanPhamEdit.ngayCapNhat = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Tìm ID
        public SanPham GetByID(long id)
        {
            return db.SanPhams.Find(id);
        }

        // Xóa
        public bool Delete(long id)
        {
            try
            {
                var sanPham = db.SanPhams.Find(id);
                db.SanPhams.Remove(sanPham);
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