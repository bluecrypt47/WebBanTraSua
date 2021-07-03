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
        public string noiDung { get; set; }

        public bool trangThai { get; set; }

        public DateTime? ngayTao { get; set; }

        public DateTime? ngayCapNhat { get; set; }
    }
}
