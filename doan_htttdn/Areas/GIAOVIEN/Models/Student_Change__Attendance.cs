﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace doan_htttdn.Areas.GIAOVIEN.Models
{
    public class Student_Change__Attendance
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string IDClass { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDStudent { get; set; }

        [Column(TypeName = "date")]
        public string NameStudent { get; set; }

        public int[] state = new int[12] { 0 , 0 , 0 , 0 , 0,0,0,0,0,0,0,0 }; 
        

    }
}