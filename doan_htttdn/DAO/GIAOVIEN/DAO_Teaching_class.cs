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
                        orderby a.NameClass descending
                        where b.IDTeacher == IDTeacher
                        select new Teacher_Attendance
                        {
                            ID = b.ID,
                            IDClass = b.IDClass,
                            IDTeacher = b.IDTeacher,
                            NameClass = a.NameClass,
                            session = b.session,
                            Day = b.Day,
                            State = b.State,
                        }).Distinct();
            return list.OrderByDescending(x => x.NameClass).Distinct();
        }
      
        public List<Teacher_Attendance> GetALL_IDteacher_IDmonth(int IDTeacher , int month)
        {
            var list = (from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        orderby b.Day descending
                        where b.IDTeacher == IDTeacher && b.Day.Month == month
                        select new Teacher_Attendance
                        {
                            ID = b.ID,
                            IDClass = b.IDClass,
                            IDTeacher = b.IDTeacher,
                            NameClass = a.NameClass,
                            session = b.session,
                            Day = b.Day,
                            State = b.State,
                        }).ToList().Distinct();
            return list.ToList();
        }
        public List<Teacher_Attendance> GetALL_IDteacher_IDLop(int IDTeacher, int IDlop)
        {
            var list = (from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        orderby b.Day descending
                        where b.IDTeacher == IDTeacher && b.IDClass == IDlop
                        select new Teacher_Attendance
                        {
                            ID = b.ID,
                            IDClass = b.IDClass,
                            IDTeacher = b.IDTeacher,
                            NameClass = a.NameClass,
                            session = b.session,
                            Day = b.Day,
                            State = b.State,
                        }).ToList().Distinct();
            return list.ToList();
        }
        public TEACHING_CLASS getbyIDclass(int ID) // ID cua teaching_class
        {
            return db.TEACHING_CLASS.Where(x => x.ID == ID).SingleOrDefault();
        }
        public string get_NameClass( int ID)// ID cua teaching_class
        {
            var Nameclass = (from a in db.TEACHING_CLASS
                             join b in db.CLASSes
                             on a.IDClass equals b.IDClass
                             where a.ID == ID
                             select b.NameClass).ToString();
            return Nameclass;
        }
        public bool Exist_Teaching_Class(TEACHING_CLASS model)
        {
            var x = db.TEACHING_CLASS.Where(a => a.IDTeacher == model.IDTeacher && a.IDClass == model.IDClass && a.session== model.session).SingleOrDefault();
            if (x != null)
                return true;
            return false;
        }
        public bool Kiemtrangaychamcong(TEACHING_CLASS model)
        {
            var mainclass = db.CLASSes.Where(a => a.IDClass == model.IDClass).SingleOrDefault();
            if (model.Day >= mainclass.StartDay && model.Day <= mainclass.FinishDay)
            {
                return true;
            }
            else
                return false;
        }
        public int Add_TEaching_class1(TEACHING_CLASS model)
        {
            if (Kiemtrangaychamcong(model))
            {
                db.TEACHING_CLASS.Add(model);
                db.SaveChanges();
                if (Exist_Teaching_Class(model))
                    return 1; // them thanh cong
                else
                    return 2; // them ko thanh cong
            }
            else
                return 3;//  ngay trung
        }
        
        public bool Update_Teaching_class(TEACHING_CLASS model)
        {
            var x = db.TEACHING_CLASS.Where(a => a.IDTeacher == model.IDTeacher && a.IDClass == model.IDClass && a.session == model.session && a.Day == model.Day).SingleOrDefault();
            if (x == null) // không ton tai
            {
                var bien = db.TEACHING_CLASS.Where(a => a.ID == model.ID).Single();
                bien.IDClass = model.IDClass;
                bien.IDTeacher = model.IDTeacher;
                bien.session = model.session;
                bien.Day = model.Day;
                bien.State = model.State;
                db.SaveChanges();
                return true;
            }
            else
            return false;
           
        }
        public int Update_Teaching_class1(TEACHING_CLASS model)
        {
            var x = db.TEACHING_CLASS.Where(a => a.IDTeacher == model.IDTeacher && a.IDClass == model.IDClass && a.session == model.session && a.Day == model.Day).SingleOrDefault();
            if (x == null) // không ton tai
            {
                if (Kiemtrangaychamcong(model))
                {
                    var bien = db.TEACHING_CLASS.Where(a => a.ID == model.ID).Single();
                    bien.IDClass = model.IDClass;
                    bien.IDTeacher = model.IDTeacher;
                    bien.session = model.session;
                    bien.Day = model.Day;
                    bien.State = model.State;
                    db.SaveChanges();
                    return 1; // update thanh cong
                }
                else
                {
                    return 2; // ngay cham cong khong nam trong thoi gian hoat dong cua lop học
                }
               
            }
            else
                return 3; // ngay cong da ton tai

        }
        public bool Delete_teaching_class( int ID)
        {
            var model = db.TEACHING_CLASS.Where(a => a.ID == ID).SingleOrDefault();
            db.TEACHING_CLASS.Remove(model);
            db.SaveChanges();
            var bien = db.TEACHING_CLASS.Where(a => a.ID == ID).SingleOrDefault();
            if ( bien == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<Luong_model> GetALLLuong( int IDteacher)
        {
            var model = from a in db.TEACHING_CLASS
                        where a.IDTeacher == IDteacher && a.Day.Year == DateTime.Today.Year
                        group a by a.Day.Month into thang
                        select new Luong_model
                        {
                            month = thang.Key,
                            year = DateTime.Today.Year,
                            numbersessiong = thang.Count(),
                            monye = thang.Count() * 100 

                        };
            return model.ToList();

        }
    }
}