namespace doan_htttdn.Areas.USER.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin_Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Admin { get; set; }
        //[Required(ErrorMessage ="Ban nhap sai ten !!!")]

        
        public string Pass { get; set; }
        //[Required(ErrorMessage ="Ban nhap sai mat khau !!!")]

    }
}
