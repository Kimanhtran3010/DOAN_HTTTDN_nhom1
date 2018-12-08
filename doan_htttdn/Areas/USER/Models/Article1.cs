namespace doan_htttdn.Areas.USER.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Article1
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Article { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Contents { get; set; }

        public string Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Admin { get; set; }
    }
}
