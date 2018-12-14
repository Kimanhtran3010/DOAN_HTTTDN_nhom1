namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEACHING_CLASS
    {
        public int ID { get; set; }

        public int IDClass { get; set; }

        public int IDTeacher { get; set; }

        public int session { get; set; }

        [Column(TypeName = "date")]
        public DateTime Day { get; set; }

        public int? State { get; set; }

        public virtual CLASS CLASS { get; set; }

        public virtual TEACHER TEACHER { get; set; }
    }
}
