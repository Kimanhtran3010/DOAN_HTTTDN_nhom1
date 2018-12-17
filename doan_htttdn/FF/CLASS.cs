namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLASS")]
    public partial class CLASS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLASS()
        {
            CLASS_STUDENT = new HashSet<CLASS_STUDENT>();
            PHANBOes = new HashSet<PHANBO>();
            TEACHING_CLASS = new HashSet<TEACHING_CLASS>();
        }

        [Key]
        public int IDClass { get; set; }

        [Required]
        [StringLength(20)]
        public string IDCourse { get; set; }

        [StringLength(100)]
        public string NameClass { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDay { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FinishDay { get; set; }

        public int? Number { get; set; }

        public int? State { get; set; }

        public virtual COURSE COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASS_STUDENT> CLASS_STUDENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANBO> PHANBOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEACHING_CLASS> TEACHING_CLASS { get; set; }
    }
}
