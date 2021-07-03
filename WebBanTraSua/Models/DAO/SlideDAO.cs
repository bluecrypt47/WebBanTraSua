using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTraSua.Models.EF;

namespace WebBanTraSua.Models.DAO
{
    public class SlideDAO
    {
        WTSDBContext db = null;

        public SlideDAO()
        {
            db = new WTSDBContext();
        }

        // Lấy danh sách
        public List<Slide> ListSlides()
        {
            return db.Slides.OrderBy(x => x.ngayTao).ToList();
        }

        // Hiện danh sách có phân trang
        public IEnumerable<Slide> ListAllPaging(string searchProducts, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;

            if (!string.IsNullOrEmpty(searchProducts))
            {
                model = model.Where(x => x.name.Contains(searchProducts));
            }

            return model.OrderByDescending(x => x.ngayTao).ToPagedList(page, pageSize);
        }

        // Thêm 
        public long insert(Slide enity)
        {
            db.Slides.Add(enity);
            db.SaveChanges();
            return enity.maSlide;
        }

        // Sửa
        public bool edit(Slide slide)
        {
            try
            {
                var slideEdit = db.Slides.Find(slide.maSlide);

                slideEdit.hinhAnh = slide.hinhAnh;
                slideEdit.name = slide.name;
                slideEdit.moTaNgan = slide.moTaNgan;
                slideEdit.ngayCapNhat = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Tìm ID
        public Slide GetByID(long id)
        {
            return db.Slides.Find(id);
        }

        // Xóa
        public bool Delete(long id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
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