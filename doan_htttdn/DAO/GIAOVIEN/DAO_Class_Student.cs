using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Areas.GIAOVIEN.Models;

namespace doan_htttdn.DAO.GIAOVIEN
{
    public class DAO_Class_Student
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<Student_Attendance> GetALl( int IDclass)
        {
            var list = (from a in db.CLASS_STUDENT
                       join b in db.STUDENTs
                       on a.IDStudent equals b.IDStudent
                       where a.IDClass == IDclass
                       orderby b.IDStudent
                       select new Student_Attendance
                       {
                           IDClass = a.IDClass,
                           IDStudent = b.IDStudent,
                           NameStudent = b.Name,
                           Session = a.Session,
                           Day = a.Day,
                           State = a.State,
                       }).Distinct();
            return list.ToList().Distinct();

        }
        //public IEnumerable<Student_Change__Attendance> chageStructure (IEnumerable<Student_Attendance> x)
        //{


        //    for ( int i = 1; i < x.Count(); i++ )
        //    {

        //    }
        //}
    }
   
}