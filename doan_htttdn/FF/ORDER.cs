namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            DETAIL_ORDERS = new HashSet<DETAIL_ORDERS>();
        }

        [Key]
        [StringLength(20)]
        public string IDOrders { get; set; }

        [StringLength(100)]
        public string NameCustomer { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string ADDRESS { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? NumberProduct { get; set; }

        [StringLength(20)]
        public string IDPromotion { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceTotal { get; set; }

        public DateTime? DATE { get; set; }

        [StringLength(100)]
        public string Payment { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public int? State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_ORDERS> DETAIL_ORDERS { get; set; }

        public virtual PROMOTION PROMOTION { get; set; }
    }
}
