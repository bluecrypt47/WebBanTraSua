namespace WebBanTraSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        [Display(Name = "Mã slide")]
        public int maSlide { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống!")]
        [StringLength(1000)]
        [Display(Name = "Hình ảnh")]
        public string hinhAnh { get; set; }

        [Required(ErrorMessage = "Tên không được để trống!")]
        [StringLength(100)]
        [Display(Name = "Tên")]
        public string name { get; set; }

        [Required(ErrorMessage = "Mô tả ngắn không được để trống!")]
        [StringLength(100)]
        [Display(Name = "Mô tả ngắn")]
        public string moTaNgan { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? ngayTao { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ngayCapNhat { get; set; }
    }
}
