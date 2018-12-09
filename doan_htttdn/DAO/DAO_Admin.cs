using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;

namespace doan_htttdn.DAO
{
    public class DAO_Admin
    {
        public QL_SCN db = new QL_SCN();
        //public ADMIN Getby(String user, string pass)
        //{
        //    return db.ADMINs.Where(x => x.IDAmin == user && x.Password == pass).SingleOrDefault();
        //}
        public int Login(String user, string pass)
        {
            var result = db.ADMINs.SingleOrDefault(x => x.IDAdmin == user);
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
        

        //-------------------------------------------------
        public List<TEACHER> List_Teacher()
        {
            return db.TEACHERs.ToList();
        }
        public bool Insert_Teacher(TEACHER tc)
        {
            if (db.TEACHERs.Add(tc) != null)
            {
                db.SaveChanges();
                return true;
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
            var bien = db.TEACHERs.Find(tc.IDTeacher);
            if (bien!=null)
            {
                bien.Name = tc.Name;
                bien.Phone = tc.Phone;
                bien.ADDRESS = tc.ADDRESS;
                bien.Email = tc.Email;
                bien.Knowledge = tc.Knowledge;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete_Teacher(int id)
        {
            var bien = db.TEACHERs.Find(id);
            if (bien != null)
            {
                db.TEACHERs.Remove(bien);
                return true;
            }
            return false;
        }
    }
}