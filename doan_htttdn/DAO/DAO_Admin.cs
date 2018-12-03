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
        public ADMIN Login(String user , string pass)
        {
            return db.ADMINs.Where(x => x.IDAmin == user && x.Password == pass).SingleOrDefault();
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