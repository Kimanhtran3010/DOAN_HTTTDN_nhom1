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

    }
}