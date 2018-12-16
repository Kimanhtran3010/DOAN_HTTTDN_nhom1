using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace doan_htttdn.Areas.GIAOVIEN.Models
{
    public class Class_model
    {
        [System.ComponentModel.DataAnnotations.Key]
        [StringLength(20)]
        public int IDClass { get; set; }

        [Required]
        [StringLength(20)]
        public string NameCourse { get; set; }

        [StringLength(100)]
        public string NameClass { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FinishDay { get; set; }

        public int? Number { get; set; }

        public int? State { get; set; }
    }
}