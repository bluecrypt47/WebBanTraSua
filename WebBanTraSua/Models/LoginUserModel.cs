using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanTraSua.Models
{
    public class LoginUserModel
    {
        [Key]
        [Required(ErrorMessage = "Email không được để trống!")]
        [Display(Name ="Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [Display(Name = "Mật khẩu")]
        public string passowrd { get; set; }
    }
}