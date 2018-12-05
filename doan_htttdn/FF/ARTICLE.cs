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
        public string IDArticler { get; set; }

        [Column("Article")]
        [Required]
        public string Article1 { get; set; }

        [Required]
        public string Summary { get; set; }

        public DateTime? Date { get; set; }

        public string Img { get; set; }

        public string Folder_Text { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IDAdmin { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string ID_Menu { get; set; }

        public virtual ADMIN1 ADMIN { get; set; }

        public virtual Menu_Article Menu_Article { get; set; }
    }
}
