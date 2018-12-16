namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin_Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin_Article()
        {
            ARTICLEs = new HashSet<ARTICLE>();
        }

        [Key]
        [StringLength(50)]
        public string IDAdmin { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTICLE> ARTICLEs { get; set; }
    }
}
