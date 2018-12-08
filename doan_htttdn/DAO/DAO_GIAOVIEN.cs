using doan_htttdn.FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Common;

namespace doan_htttdn.DAO
{
    public class DAO_GIAOVIEN
    {
        public QL_SCN db = new QL_SCN();
        //public ADMIN Getby(String user, string pass)
        //{
        //    return db.ADMINs.Where(x => x.IDAmin == user && x.Password == pass).SingleOrDefault();
        //}
        public int Login_Giaovien(String user, string pass)
        {
            var result = db.ACCOUNTs.SingleOrDefault(x => x.IDTeacher == user);
            if (result == null)
                return 0;
            else
            {
                if (result.Status == 0)
                    return -1;
                else
                {
                    if (result.Password == pass)
                        return 1;
                    else
                        return -2;
                }
            }

        }

        public bool Insert(ADMIN aDMIN)
        {
            try
            {
                db.ADMINs.Add(aDMIN);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }


        //TEACHER-------------------------------------------------------
        public List<TEACHER> List_Teacher()
        {
            var ds = db.TEACHERs.ToList();
            return ds;
        }
        public TEACHER GetTeacher(int id)
        {
            return db.TEACHERs.Find(id);
        }
        public void Insert_Teacher(TEACHER teacher)
        {
            db.TEACHERs.Add(teacher);
            db.SaveChanges();
        }

        public bool Update_Teacher(TEACHER tc)
        {
            var teacher = db.TEACHERs.Find(tc.IDTeacher);
            if (teacher != null)
            {
                teacher.Name = tc.Name;
                teacher.Phone = tc.Phone;
                teacher.ADDRESS = tc.ADDRESS;
                teacher.Email = tc.Email;
                teacher.Knowledge = tc.Knowledge;
                db.SaveChanges();
                return true;
            }
            else
                return false;
            

        }
        //public bool Delete_Teacher(int id_teacher)
        //{
        //    TEACHER tc = db.TEACHERs.Find(id_teacher);
        //    if (tc == null)
        //    {
        //        return false;
        //    }
                
        //    else
        //    {
        //        db.TEACHERs.Remove(tc);
        //        db.SaveChanges();
        //    }
        //    return true;

        //}

        public bool Delete_teacher(int id)
        {
            var bien = db.TEACHERs.Find(id);
            if (bien != null)
            {
                db.TEACHERs.Remove(bien);
                db.SaveChanges();
                return true;
            }
            else
                return false;

        }

        
        
    }
}