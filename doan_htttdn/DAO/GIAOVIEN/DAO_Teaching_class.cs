using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Areas.GIAOVIEN.Models;

namespace doan_htttdn.DAO.GIAOVIEN
{
    public class DAO_Teaching_class
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<Teacher_Attendance> GetALL( int IDTeacher)
        {
            var list = (from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        orderby b.Day descending
                        where b.IDTeacher == IDTeacher
                        select new Teacher_Attendance
                        {
                            IDClass = b.IDClass,
                            IDTeacher = b.IDTeacher,
                            NameClass = a.NameClass,
                            session = b.session,
                            Day = b.Day,
                            State = b.State,
                        }).Distinct();
            return list.Distinct();
        }
    }
}