using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;

namespace doan_htttdn.DAO
{
    public class DAO_Course
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<COURSE> GetAll()
        {
            return db.COURSEs.ToList();
        }
        public List<COURSE> GetNamecouse ()
        {
            var a = from x in db.COURSEs
                  select x;
            return a.ToList();
        }
    }
}