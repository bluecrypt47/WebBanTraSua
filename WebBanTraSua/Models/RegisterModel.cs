using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanTraSua.Models
{
    public class RegisterModel
    {
        [Key]
        [Required(ErrorMessage = "Email không được để trống!")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [Display(Name = "Mật khẩu")]
        [StringLength(1000, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự!")]
        public string password { get; set; }

        [Required(ErrorMessage = "Nhập lại Mật khẩu không được để trống!")]
        [Display(Name = "Nhập lại Mật khẩu")]
        [Compare("password", ErrorMessage = "Không khớp với mật khẩu!!!")]
        public string rePassword { get; set; }

        [Required(ErrorMessage = "Tên người dùng không được để trống!")]
        [Display(Name = "Tên người dùng")]
        public string name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string address { get; set; }

        [Display(Name = "Số điện thoại")]
        public string phoneNumber { get; set; }

    }
}