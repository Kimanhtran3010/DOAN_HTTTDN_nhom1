namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTICLE")]
    public partial class ARTICLE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string ID_Article { get; set; }

        [Required]
        public string Title { get; set; }

        public string Summary { get; set; }

        [Required]
        public string Contents { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        public string Image { get; set; }

        public int State { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ID_Admin { get; set; }

        public virtual ADMIN ADMIN { get; set; }
    }
}
