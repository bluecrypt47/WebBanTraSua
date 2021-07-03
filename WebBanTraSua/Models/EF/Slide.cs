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
        public int maSlide { get; set; }

        [StringLength(1000)]
        public string hinhAnh { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string moTaNgan { get; set; }

        public DateTime? ngayTao { get; set; }

        public DateTime? ngayCapNhat { get; set; }
    }
}
