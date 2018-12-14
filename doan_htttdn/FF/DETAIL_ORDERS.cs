namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETAIL_ORDERS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOrders { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IDRobot { get; set; }

        public int? Number { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public virtual ORDERS ORDERS { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
