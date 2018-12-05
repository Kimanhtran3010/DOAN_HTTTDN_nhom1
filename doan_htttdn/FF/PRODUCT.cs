namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            DETAIL_ORDERS = new HashSet<DETAIL_ORDERS>();
        }

        [Key]
        [StringLength(20)]
        public string IDRobot { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? Number { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Contents { get; set; }

        public int? State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_ORDERS> DETAIL_ORDERS { get; set; }
    }
}
