namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADMIN()
        {
            ARTICLEs = new HashSet<ARTICLEs>();
        }

        [Key]
        [StringLength(20)]
        public string IDAdmin { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Menu { get; set; }

        [StringLength(100)]
        public string Pass { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTICLEs> ARTICLEs { get; set; }
    }
}
