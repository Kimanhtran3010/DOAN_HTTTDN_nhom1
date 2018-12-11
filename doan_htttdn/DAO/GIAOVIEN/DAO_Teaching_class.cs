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
        public IEnumerable<Teacher_Attendance> GetTodayClasses()
        {
            /* var list = (from a in db.CLASS_STUDENT
                         join b in db.CLASSes
                         on a.IDClass equals b.IDClass
                         where a.Day.Day == DateTime.Now.Day
                         && a.Day.Month == DateTime.Now.Month
                         && a.Day.Year == DateTime.Now.Year
                         select new Teacher_Attendance
                         {
                             IDClass = a.IDClass,
                             NameClass = b.NameClass,
                             session = a.Session,
                             Day = a.Day,
                             State = a.State
                         }
                         ).ToList();*/
            var list = (from a in db.CLASS_STUDENT
                        from b in db.CLASSes
                        where a.IDClass == b.IDClass
                        where a.Day.Day == DateTime.Now.Day
                         && a.Day.Month == DateTime.Now.Month
                         && a.Day.Year == DateTime.Now.Year
                        where !(db.TEACHING_CLASS.Any(x => x.IDClass == a.IDClass))

                        select new Teacher_Attendance
                        {
                            IDClass = a.IDClass,
                            NameClass = b.NameClass,
                            session = a.Session,
                            Day = a.Day,
                            State = a.State
                        }
                        ).Distinct();
            return list.Distinct();
        }
        public IEnumerable<Teacher_Attendance> GetTodayAdded(int IDTeacher)
        {

            var list = (from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        orderby b.Day descending
                        where b.IDTeacher == IDTeacher
                        where b.Day.Day == DateTime.Now.Day
                         && b.Day.Month == DateTime.Now.Month
                         && b.Day.Year == DateTime.Now.Year
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
        public void Insert(TEACHING_CLASS tc)
        {
            db.TEACHING_CLASS.Add(tc);
            db.SaveChanges();
        }
        public void Delete(int IDClass, int IDTeacher)
        {
            db.TEACHING_CLASS.RemoveRange(db.TEACHING_CLASS.Where(x => x.IDClass == IDClass).Where(x => x.IDTeacher == IDTeacher)
                                                            .Where(x => x.Day.Day == DateTime.Now.Day)
                                                            .Where(x => x.Day.Month == DateTime.Now.Month)
                                                            .Where(x => x.Day.Year == DateTime.Now.Year));
            db.SaveChanges();
        }
    }
}