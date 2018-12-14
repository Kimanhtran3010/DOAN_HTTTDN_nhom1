using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
//using PagedList;
//using PagedList.Mvc;

namespace doan_htttdn.DAO
{
    public class DAO_Product
    {
        private QL_SCN db = new QL_SCN();
        public IEnumerable<PRODUCT> listpd(int page, int pagesize)
        {
            return db.PRODUCT.OrderByDescending(x => x.IDRobot).ToPagedList(page, pagesize);
        }
        public PRODUCT ViewDetail(string ID)
        {
            return db.PRODUCT.Where(x => x.IDRobot == ID).SingleOrDefault();
        }

        public IEnumerable<PRODUCT> search(string tk, int page, int pagesize)
        {
            return db.PRODUCT.Where(x => x.IDRobot == tk || x.Name == tk).OrderByDescending(x => x.IDRobot).ToPagedList(page, pagesize);
        }

        public IEnumerable<PRODUCT> top3_pd()
        {
            return db.PRODUCT.Take(3).ToList();
        }
    }
}