using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Common;

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

//        public bool Insert(Admin_Article aDMIN)
//        {
//            try
//            {
//                db.Admin_Article.Add(aDMIN);
//                db.SaveChanges();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }

//        }


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
    }
}