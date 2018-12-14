namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROMOTION")]
    public partial class PROMOTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROMOTION()
        {
            ORDERS = new HashSet<ORDERS>();
        }

        [Key]
        [StringLength(20)]
        public string IDPromotion { get; set; }

        [StringLength(20)]
        public string Value { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidDay { get; set; }

        public int? State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERS> ORDERS { get; set; }
    }
}
