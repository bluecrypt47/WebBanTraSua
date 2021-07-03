namespace WebBanTraSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        public bool maLoaiTaiKhoan { get; set; }

        [Required]
        [StringLength(1000)]
        public string matKhau { get; set; }

        [Required]
        [StringLength(100)]
        public string tenNguoiDung { get; set; }

        [StringLength(1000)]
        public string diaChi { get; set; }

        [StringLength(11)]
        public string sdt { get; set; }

        public DateTime? ngayTao { get; set; }

        public DateTime? ngayCapNhat { get; set; }

        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}
