using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Areas.ADMIN.Models;

namespace doan_htttdn.DAO.ADMIN
{
    public class DAO_Teaching_class
    {
        QL_SCN db = new QL_SCN();
        //cham cong
        public IEnumerable<Teaching_Model> GetAll()
        {
            var model = from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        join c in db.TEACHERs
                        on b.IDTeacher equals c.IDTeacher
                        where a.State == 1
                        select new Teaching_Model
                        {
                            ID = b.ID,
                            IDClass = b.IDClass,
                            NameClass = a.NameClass,
                            IDTeacher = b.IDTeacher,
                            Nameteacher = c.Name,
                            session = b.session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }
        public List<CLASS> GetAllClass()
        {
            return db.CLASSes.ToList();
        }
        public List<TEACHER> GetAllTeacher()
        {
            return db.TEACHERs.ToList();
        }
        public IEnumerable<Teaching_Model> GetbyIDClass( int IDclass)
        {
            var model = from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        join c in db.TEACHERs
                        on b.IDTeacher equals c.IDTeacher
                        where a.State == 1 && b.IDClass == IDclass
                        select new Teaching_Model
                        {
                            ID = b.ID,
                            IDClass = b.IDClass,
                            NameClass = a.NameClass,
                            IDTeacher = b.IDTeacher,
                            Nameteacher = c.Name,
                            session = b.session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }
        public IEnumerable<Teaching_Model> GetbyDAy(DateTime thoigian)
        {
            var model = from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        join c in db.TEACHERs
                        on b.IDTeacher equals c.IDTeacher
                        where a.State == 1 && b.Day.Month == thoigian.Month && b.Day.Year == thoigian.Year
                        select new Teaching_Model
                        {
                            ID = b.ID,
                            IDClass = b.IDClass,
                            NameClass = a.NameClass,
                            IDTeacher = b.IDTeacher,
                            Nameteacher = c.Name,
                            session = b.session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }
        public IEnumerable<Teaching_Model> GetbyDAyAndIDClass(DateTime thoigian , int IDClass)
        {
            var model = from a in db.CLASSes
                        join b in db.TEACHING_CLASS
                        on a.IDClass equals b.IDClass
                        join c in db.TEACHERs
                        on b.IDTeacher equals c.IDTeacher
                        where a.State == 1 && b.Day.Month == thoigian.Month && b.Day.Year == thoigian.Year && b.IDClass == IDClass
                        select new Teaching_Model
                        {
                            ID = b.ID,
                            IDClass = b.IDClass,
                            NameClass = a.NameClass,
                            IDTeacher = b.IDTeacher,
                            Nameteacher = c.Name,
                            session = b.session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }

        // phan bố giảng dạy

       public IEnumerable<Teaching_class_model> _GetAllPhanphoi()
        {
            var model = from a in db.TEACHERs
                        join b in db.PHANBOes
                        on a.IDTeacher equals b.IDTeacher
                        join c in db.CLASSes
                        on b.IDClass equals c.IDClass
                        join d in db.COURSEs
                        on c.IDCourse equals d.IDCourse
                        select new Teaching_class_model
                        {
                            IDClass = c.IDClass,
                            NameClass = c.NameClass,
                            NameCourse = d.Name,
                            IDteacher = b.IDTeacher,
                            NameTeacher = a.Name,
                            Number = c.Number,
                            StartDay = c.StartDay,
                            FinishDay = c.FinishDay,
                        };
            return model.Distinct().ToList();
        }
        public IEnumerable<Teaching_class_model> _GetphabobyIDlopandIDteacher(int IDclass , int IDteacher)
        {
            var model = from a in db.TEACHERs
                        join b in db.PHANBOes
                        on a.IDTeacher equals b.IDTeacher
                        join c in db.CLASSes
                        on b.IDClass equals c.IDClass
                        join d in db.COURSEs
                        on c.IDCourse equals d.IDCourse
                        where b.IDClass == IDclass && b.IDTeacher == IDteacher
                        select new Teaching_class_model
                        {
                            IDClass = c.IDClass,
                            NameClass = c.NameClass,
                            NameCourse = d.Name,
                            IDteacher = b.IDTeacher,
                            NameTeacher = a.Name,
                            Number = c.Number,
                            StartDay = c.StartDay,
                            FinishDay = c.FinishDay,
                        };
            return model.Distinct().ToList();
        }
        public IEnumerable<Teaching_class_model> _GetphabobyIDlop(int IDclass)
        {
            var model = from a in db.TEACHERs
                        join b in db.PHANBOes
                        on a.IDTeacher equals b.IDTeacher
                        join c in db.CLASSes
                        on b.IDClass equals c.IDClass
                        join d in db.COURSEs
                        on c.IDCourse equals d.IDCourse
                        where b.IDClass == IDclass 
                        select new Teaching_class_model
                        {
                            IDClass = c.IDClass,
                            NameClass = c.NameClass,
                            NameCourse = d.Name,
                            IDteacher = b.IDTeacher,
                            NameTeacher = a.Name,
                            Number = c.Number,
                            StartDay = c.StartDay,
                            FinishDay = c.FinishDay,
                        };
            return model.Distinct().ToList();
        }
        public bool Exist_Teaching_class(int IDclass, int IDteacher)
        {

            var model = db.PHANBOes.Where(x => x.IDClass == IDclass && x.IDTeacher == IDteacher).SingleOrDefault();
            if (model != null)
                return true;
            else
                return false;

        }
        public bool Add_phanbo( int IDClass, int IDteacher)
        {
            if (!Exist_Teaching_class(IDClass, IDteacher))
            {
                PHANBO pb = new PHANBO();
                pb.IDClass = IDClass;
                pb.IDTeacher = IDteacher;
                db.PHANBOes.Add(pb);
                db.SaveChanges();
                if (Exist_Teaching_class(IDClass, IDteacher))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public bool Delete_phanbo(int IDClass, int IDteacher)
        {
           
                var model = db.PHANBOes.Where(x => x.IDClass == IDClass && x.IDTeacher == IDteacher).SingleOrDefault();
            db.PHANBOes.Remove(model);
                db.SaveChanges();
                if (!Exist_Teaching_class(IDClass, IDteacher))
                    return true; 
                else
                    return false;
            
        }
    }
    
}