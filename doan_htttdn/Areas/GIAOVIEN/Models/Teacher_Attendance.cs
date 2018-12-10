using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace doan_htttdn.Areas.GIAOVIEN.Models
{
    public class Teacher_Attendance
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDClass { get; set; }


        public string NameClass { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDTeacher { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int session { get; set; }

        [Column(TypeName = "date")]
        public DateTime Day { get; set; }

        public int? State { get; set; }
    }
}