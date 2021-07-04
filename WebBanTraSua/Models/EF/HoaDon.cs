namespace WebBanTraSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [Display(Name = "Mã hóa đơn")]
        public long maHoaDon { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên người mua")]
        public string tenNguoiMua { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Số điện thoại")]
        public string sdt { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Địa chỉ")]
        public string diaChi { get; set; }

        [StringLength(1000)]
        [Display(Name = "Ghi chú")]
        public string ghiChu { get; set; }

        [Display(Name = "Ngày mua")]
        public DateTime? ngayMua { get; set; }

        [Display(Name = "Số lượng")]
        public int? soLuong { get; set; }

        [Display(Name = "Tổng tiền")]
        public int? tongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
