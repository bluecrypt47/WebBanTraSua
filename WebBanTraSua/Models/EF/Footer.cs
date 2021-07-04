namespace WebBanTraSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        [Key]
        public int maFooter { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Nội dung")]
        public string noiDung { get; set; }

        [Display(Name = "Trạng thái")]
        public bool trangThai { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? ngayTao { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ngayCapNhat { get; set; }
    }
}
