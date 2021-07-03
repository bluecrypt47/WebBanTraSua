using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanTraSua.Models
{
    public class LoginModel
    {
        private string email;
        private string matKhau;

        [Required(ErrorMessage = "Email không được để trống!")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}