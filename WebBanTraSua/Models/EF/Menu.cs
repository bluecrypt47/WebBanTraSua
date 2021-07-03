namespace WebBanTraSua.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Menu
    {
        [Key]
        public int maMenu { get; set; }

        [Required]
        [StringLength(100)]
        public string tenMenu { get; set; }

        [Required]
        [StringLength(100)]
        public string duongDan { get; set; }

        [Required]
        [StringLength(100)]
        public string targets { get; set; }

        public bool trangThai { get; set; }
    }
}
