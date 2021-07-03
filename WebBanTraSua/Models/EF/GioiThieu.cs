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
        [Required]
        public string noiDung { get; set; }

        public DateTime? ngayTao { get; set; }

        public DateTime? ngayCapNhat { get; set; }
    }
}
