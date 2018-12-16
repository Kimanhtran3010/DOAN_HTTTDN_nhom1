using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.Areas.GIAOVIEN.Models;
namespace doan_htttdn.Areas.ViewModel
{
    public class ChamCongIndexViewModel
    {
        public List<Teacher_Attendance> All_Teacher_Attendance { get; set; }
        public List<Teacher_Attendance> Custom_Teacher_Attendance { get; set; }
        public List<Teacher_Attendance> Custom_Teacher_Attendance_del { get; set; }
    }
}