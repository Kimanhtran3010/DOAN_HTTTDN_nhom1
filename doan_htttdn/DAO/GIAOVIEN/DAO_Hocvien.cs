﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;

namespace doan_htttdn.DAO.GIAOVIEN
{
    public class DAO_Hocvien
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<STUDENT> GetALL()
        {
            return db.STUDENTs.ToList();
        }
        public IEnumerable<STUDENT> GetbyIDClass (string IDclass)
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