namespace Model1.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COURSE")]
    public partial class COURSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURSE()
        {
            CLASSes = new HashSet<CLASS>();
            RIGISTRATION_COURSE = new HashSet<RIGISTRATION_COURSE>();
        }

        [Key]
        [StringLength(20)]
        public string IDCourse { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        public int? Maxnumber { get; set; }

        public string Time { get; set; }

        public string Contents { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fee { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASS> CLASSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RIGISTRATION_COURSE> RIGISTRATION_COURSE { get; set; }
    }
}
