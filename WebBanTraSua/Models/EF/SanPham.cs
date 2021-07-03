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
        public long maSanPham { get; set; }

        public long maLoaiSanPham { get; set; }

        [StringLength(100)]
        public string tenSanPham { get; set; }

        [StringLength(1000)]
        public string hinhAnh { get; set; }

        public DateTime? ngayTao { get; set; }

        public DateTime? ngayCapNhat { get; set; }

        public double? giaBan { get; set; }

        [StringLength(100)]
        public string dvt { get; set; }

        public double? giamGia { get; set; }

        [StringLength(1000)]
        public string gioiThieuSanPham { get; set; }

        public bool sanPhamMoi { get; set; }

        public bool sanPhamNoiBat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
