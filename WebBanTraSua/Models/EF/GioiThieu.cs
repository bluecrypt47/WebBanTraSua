namespace WebBanTraSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioiThieu")]
    public partial class GioiThieu
    {
        public int id { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(1000000, MinimumLength = 100, ErrorMessage = "Nội dung phải có trên 100 ký tự")]
        [Display(Name = "Nội dung")]
        public string noiDung { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? ngayTao { get; set; }


        [Display(Name = "Ngày cập nhật")]
        public DateTime? ngayCapNhat { get; set; }
    }
}
