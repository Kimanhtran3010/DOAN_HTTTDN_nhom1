namespace doan_htttdn.FF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDTeacher { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public virtual TEACHER TEACHER { get; set; }
    }
}
