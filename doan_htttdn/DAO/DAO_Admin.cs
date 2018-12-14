using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Common;
using doan_htttdn.Areas.GIAOVIEN.Models;

namespace doan_htttdn.DAO
{
    public class DAO_Admin
    {
        public QL_SCN db = new QL_SCN();
        //public ADMIN Getby(String user, string pass)
        //{
        //    return db.ADMINs.Where(x => x.IDAmin == user && x.Password == pass).SingleOrDefault();
        //}
        public int Login(string user, string pass)
        {
            var result = db.Admin_Article.SingleOrDefault(x => x.IDAdmin == user);
            if (result == null)
                return 0;
            else
            {
                if (result.Status == 0)
                    return -1;
                else
                {
                    if (result.Pass == pass)
                        return 1;
                    else
                        return -2;
                }
            }

        }

        


        //TEACHER-------------------------------------------------
        public List<TEACHER> List_Teacher()
        {
            return db.TEACHERs.ToList();
        }
        public int Exist_Teacher( string email)
        {
            var _teacher = db.TEACHERs.Where(x => x.Email == email).SingleOrDefault();
            if (_teacher != null)
            {
                return _teacher.IDTeacher;
            }
            return -1;
        }
        public bool Insert_Teacher(TEACHER tc)
        {
            var tmp = Exist_Teacher(tc.Email);
            if (tmp == -1)
            {
                db.TEACHERs.Add(tc);
                db.SaveChanges();
                var bien_tmp = Exist_Teacher(tc.Email);
                if (bien_tmp != -1)
                {
                    ACCOUNT tk = new ACCOUNT();
                    tk.IDTeacher = bien_tmp;
                    tk.Username = tc.Email;
                    tk.Password = Encryptor.MD5Hash(tc.Email);
                    tk.Status = 1;
                    db.ACCOUNTs.Add(tk);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
                
            }
            else
                return false;
        }
        public TEACHER Get_Teacher(int id)
        {
            return db.TEACHERs.Find(id);
        }
        public bool Update_Teacher(TEACHER tc)
        {
            try
            {
                var bien = db.TEACHERs.Find(tc.IDTeacher);
                if (bien != null)
                {
                    bien.Name = tc.Name;
                    bien.Sex = tc.Sex;
                    bien.Phone = tc.Phone;
                    bien.ADDRESS = tc.ADDRESS;
                    bien.Email = tc.Email;
                    bien.Knowledge = tc.Knowledge;
                    bien.Status = tc.Status;
                    db.SaveChanges();
                    var bien1 = db.ACCOUNTs.Find(tc.IDTeacher);
                    if (bien1 != null)
                    {
                        bien1.Status = tc.Status;
                        db.SaveChanges();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

       
        public bool Delete_Teacher(int id)
        {
            var bien = db.TEACHERs.Where(a => a.IDTeacher == id).SingleOrDefault();
            var temp = db.TEACHING_CLASS.Where(a => a.IDTeacher == id).SingleOrDefault();
            if (bien != null) // ton tai
            {
                if(temp != null) // ton tai
                {
                    return false;
                }
                else // khong ton tai
                {
                    var bien1 = db.ACCOUNTs.Where(a => a.IDTeacher == id).SingleOrDefault();
                    db.ACCOUNTs.Remove(bien1);
                    db.SaveChanges();
                    db.TEACHERs.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }
         public List<TEACHER> Search_Teacher(string key)
        {
            
              return db.TEACHERs.Where(x => x.Name.Contains(key) || x.ADDRESS.Contains(key) || x.Knowledge.Contains(key)).ToList();       
            
        }


        //STUDENT--------------------------------------------------------
        public List<STUDENT> List_Student()
        {
            return db.STUDENTs.ToList();
        }
        public List<STUDENT> Search_Student(string key)
        {

            return db.STUDENTs.Where(x => x.Name.Contains(key) || x.ADDRESS.Contains(key) || x.NameParent.Contains(key)).ToList();

        }
        public bool Insert_Student(STUDENT student)
        {
            try
            {
                db.STUDENTs.Add(student);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public STUDENT Get_student(int id)
        {
            return db.STUDENTs.Find(id);
        }
        public bool Update_Student(STUDENT student)
        {
            var bien = db.STUDENTs.Where(x => x.IDStudent == student.IDStudent).SingleOrDefault();
            if (bien != null)
            {
                bien.Name = student.Name;
                bien.Sex = student.Sex;
                bien.Born = student.Born;
                bien.NameParent = student.NameParent;
                bien.PHONE = student.PHONE;
                bien.ADDRESS = student.ADDRESS;
                bien.EMAIL = student.EMAIL;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
         public bool Delete_Student(int id)
        {
            var bien = db.STUDENTs.Find(id);
            if (bien != null)
            {
                CLASS_STUDENT bien1 = db.CLASS_STUDENT.Where(x => x.IDStudent == id).SingleOrDefault();
                if (bien1 != null)
                {
                    db.CLASS_STUDENT.Remove(bien1);
                    db.SaveChanges();
                    db.STUDENTs.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    db.STUDENTs.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }


        //Class----------------------------------------------------------------------------
        public IEnumerable<Class_model> Get_Class()
        {
            var list = (from x in db.CLASSes
                        join y in db.COURSEs
                        on x.IDCourse equals y.IDCourse
                        select new Class_model
                        {
                            IDClass = x.IDClass,
                            NameClass = x.NameClass,
                            NameCourse = y.Name,
                            StartDay = x.StartDay,
                            FinishDay = x.FinishDay,
                            Number = x.Number,
                            State = x.State
                        }
                        );
            return list.ToList();
        }

        public List<Class_model> Search_Class(string key)
        {
            var bien1 = Get_Class();
            return bien1.Where(x => x.NameClass.Contains(key) || x.NameCourse.Contains(key)).ToList();
        }

        public IEnumerable<COURSE> GetName_Course()
        {
            var bien = (from a in db.COURSEs
                        select a);
            return bien.ToList().Distinct();
        }
         public bool Insert_Class(CLASS lop)
        {
            try
            {
                lop.Number = 0;
                db.CLASSes.Add(lop);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public CLASS Get_DetailClass(int id)
        {
            return db.CLASSes.Find(id);
        }
        public bool Update_Class(CLASS lop)
        {
            var bien = db.CLASSes.Where(x => x.IDClass == lop.IDClass).SingleOrDefault();
            if (bien != null)
            {
                bien.IDCourse = lop.IDCourse;
                bien.NameClass = lop.NameClass;
                bien.StartDay = lop.StartDay;
                bien.FinishDay = lop.FinishDay;
                bien.State = lop.State;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}