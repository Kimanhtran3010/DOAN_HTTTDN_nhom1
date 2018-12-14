//using doan_htttdn.FF;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using doan_htttdn.FF;


namespace doan_htttdn.DAO
{
    public class DAO_GIAOVIEN
    {
        public QL_SCN db = new QL_SCN();
        public ACCOUNT GetbyAccpunt(String user, string pass)
        {
            return db.ACCOUNTs.Where(x => x.Username == user && x.Password == pass).SingleOrDefault();
        }
        public int Login_Giaovien(string user, string pass)
        {
            var result = db.ACCOUNTs.SingleOrDefault(x => x.Username == user);
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

//        }
//        public TEACHER GetbyID(int ID)
//        {
//            return db.TEACHERs.Where(x => x.IDTeacher == ID).SingleOrDefault();
//        }
        
//        public bool Update(TEACHER tEACHER)
//        {
//            var tc = db.TEACHERs.Where(x => x.IDTeacher == tEACHER.IDTeacher).SingleOrDefault();
//            if (tc != null)
//            {
//               tc.Name = tEACHER.Name;
//                tc.Phone = tEACHER.Phone;
//                tc.ADDRESS = tEACHER.ADDRESS;
//                tc.Email = tEACHER.Email;
//                tc.Knowledge = tEACHER.Knowledge;
//                db.SaveChanges();
//                return true;
//            }
//            return false;

//        }

//    }
//}