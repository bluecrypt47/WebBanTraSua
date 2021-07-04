namespace WebBanTraSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [Display(Name = "Mã sản phẩm")]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống!")]
        public long maSanPham { get; set; }


        [Display(Name = "Loại sản phẩm")]
        [Required(ErrorMessage = "Mã loại không được để trống!")]
        public long maLoaiSanPham { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
        public string tenSanPham { get; set; }

        [StringLength(1000)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Hình ảnh không được để trống!")]
        public string hinhAnh { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? ngayTao { get; set; }

        [Display(Name = "Ngày cập nhập")]
        public DateTime? ngayCapNhat { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán không được để trống!")]
        public double? giaBan { get; set; }

        [StringLength(100)]
        [Display(Name = "Đơn vị tính")]
        [Required(ErrorMessage = "Đơn vị tính không được để trống!")]
        public string dvt { get; set; }

        [Display(Name = "Giảm giá")]
        public double? giamGia { get; set; }

        [Display(Name = "Giới thiệu")]
        [StringLength(1000)]
        public string gioiThieuSanPham { get; set; }

        [Display(Name = "Sản phẩm mới")]
        public bool sanPhamMoi { get; set; }

        [Display(Name = "Sản phẩm nổi bật")]
        public bool sanPhamNoiBat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
