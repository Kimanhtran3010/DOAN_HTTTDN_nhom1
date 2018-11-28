namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENT")]
    public partial class STUDENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT()
        {
            CLASS_STUDENT = new HashSet<CLASS_STUDENT>();
        }

        [Key]
        [StringLength(20)]
        public string IDStudent { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Born { get; set; }

        [Required]
        [StringLength(100)]
        public string NameParent { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        [StringLength(200)]
        public string ADDRESS { get; set; }

        [StringLength(200)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASS_STUDENT> CLASS_STUDENT { get; set; }
    }
}
