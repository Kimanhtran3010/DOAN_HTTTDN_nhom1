using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;



namespace doan_htttdn.DAO.GIAOVIEN
{
    public class DAO_Hocvien
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<STUDENT> GetALL( int IDTeacher)
        {
            IEnumerable<STUDENT> list = (from a in db.PHANBOes
                                         join c in db.CLASS_STUDENT  on a.IDClass equals c.IDClass
                                         join d in db.STUDENTs on c.IDStudent equals d.IDStudent
                                         where a.IDTeacher == IDTeacher
                                         select d).Distinct();

            return list.Distinct();
        }
        public IEnumerable<STUDENT> GetbyIDClass (int IDclass)
        {
            IEnumerable<STUDENT> list = (from a in db.CLASS_STUDENT
                       join b in db.STUDENTs
                       on a.IDStudent equals b.IDStudent
                       where a.IDClass == IDclass
                       select b).Distinct();

            return list.Distinct();

        }
    }
}
