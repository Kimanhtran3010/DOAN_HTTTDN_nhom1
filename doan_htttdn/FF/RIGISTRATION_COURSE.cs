namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIGISTRATION_COURSE
    {
        [Key]
        public int IDRegist { get; set; }

        [StringLength(100)]
        public string NameParent { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string NameStudent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BIRTHDAY { get; set; }

        public string ADDRESS { get; set; }

        [StringLength(20)]
        public string IDCourse { get; set; }

        [StringLength(200)]
        public string State { get; set; }

        public virtual COURSE COURSE { get; set; }
    }
}
