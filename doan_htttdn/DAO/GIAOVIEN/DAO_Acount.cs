using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Areas.GIAOVIEN.Models;
using doan_htttdn.Common;

namespace doan_htttdn.DAO.GIAOVIEN
{

    public class DAO_Acount
    {
        QL_SCN db = new QL_SCN();
        public int Change_Pass( Acount_model model)
        {
            var acc = db.ACCOUNTs.Where(x => x.IDTeacher == model.IDTeacher).SingleOrDefault();
            if (acc != null) // ton tai
            {
                if (Encryptor.MD5Hash(model.oldpass).ToString() == acc.Password)
                {
                    acc.Password = Encryptor.MD5Hash(model.newpass).ToString();
                    db.SaveChanges();
                    return 0; // thanh cong
                }
                else
                    return 1; // mat khau khong dung
            }
            else
                return 2; // khong ton tai
            
        }
    }
}