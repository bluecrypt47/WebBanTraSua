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

        [Required(ErrorMessage = "Email không được để trống!")]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Tài khoản Quản trị")]
        public bool maLoaiTaiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [StringLength(1000)]
        [Display(Name = "Mật khẩu")]
        public string matKhau { get; set; }

        [Required(ErrorMessage = "Tên người dùng không được để trống!")]
        [StringLength(100)]
        [Display(Name = "Tên người dùng")]
        public string tenNguoiDung { get; set; }

        [StringLength(1000)]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string diaChi { get; set; }

        [StringLength(11)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string sdt { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? ngayTao { get; set; }

        [Display(Name = "Ngày cập nhập")]
        public DateTime? ngayCapNhat { get; set; }

        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}
