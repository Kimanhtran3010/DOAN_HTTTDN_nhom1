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
        public IEnumerable<Student_Attendance> GetALl(int IDclass)
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
                            Day = (DateTime)a.Day,
                            State = a.State,
                        }).Distinct();
            return list.ToList().Distinct();

        }
        public Teacher_Attendance getByClassInfoByID(int ID)
        {
            var model = (from a in db.CLASS_STUDENT
                        where a.IDClass == ID
                        select new Teacher_Attendance
                        {
                            IDClass = ID,
                            session = a.Session,
                            Day = (DateTime)a.Day,
                            State = a.State
                        }).FirstOrDefault();
            return model;
        }
        public string GetName_student (int IDstudent)
        {
            var name = (from a in db.STUDENTs
                        where a.IDStudent == IDstudent
                        select a).SingleOrDefault();
            return name.Name.ToString();
        }
        
        public List<Student_Change__Attendance> _GetALL(int IDClass)
        {
            var model = (from b in db.CLASS_STUDENT
                        where b.IDClass == IDClass
                        orderby b.IDStudent
                        select b).ToList();
            List<Student_Change__Attendance> list = new List<Student_Change__Attendance>(); 
           for (int i = 0;  i< model.Count; i ++)
            {
                Student_Change__Attendance std = new Student_Change__Attendance();
                std.IDClass = model[i].IDClass;
                std.IDStudent = model[i].IDStudent;
                std.NameStudent = GetName_student(model[i].IDStudent).ToString();
                 // session = std.state[] + 1;
                for (int j = i; j < (i + 12); j ++)
                {
                    if ((int)model[j].State == 1)
                        std.state[model[j].Session - 1] = true;
                    else
                        std.state[model[j].Session - 1] = false;
                }
                list.Add(std);
                i = i + 11;
            }

            return list;
        }
        public List<Student_Change__Attendance> GetALL(int IDteacher)
        {
            var model = (from b in db.CLASS_STUDENT
                         join a in db.TEACHING_CLASS
                         on b.IDClass equals a.IDClass
                         where a.IDTeacher == IDteacher
                         orderby b.IDStudent
                         select b).Distinct().ToList();
            List<Student_Change__Attendance> list = new List<Student_Change__Attendance>();
            for (int i = 0; i < model.Count; i++)
            {
                Student_Change__Attendance std = new Student_Change__Attendance();
                std.IDClass = model[i].IDClass;
                std.IDStudent = model[i].IDStudent;
                std.NameStudent = GetName_student(model[i].IDStudent).ToString();
                // session = std.state[] + 1;
                for (int j = i; j < (i + 12); j++)
                {
                    if ((int)model[j].State == 1)
                        std.state[model[j].Session - 1] = true;
                    else
                        std.state[model[j].Session - 1] = false;
                }
                list.Add(std);
                i = i + 11;
            }

            return list;
        }

        public bool Update( CLASS_STUDENT model)
        {
            var bien = (from a in db.CLASS_STUDENT
                       where a.IDClass == model.IDClass && a.IDStudent == model.IDStudent && a.Session == model.Session
                       select a).SingleOrDefault();
            if (bien != null)
            {
                bien.State = model.State;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        
    }
   
}