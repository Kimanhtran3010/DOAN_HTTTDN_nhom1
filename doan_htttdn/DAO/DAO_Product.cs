using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using PagedList;
using PagedList.Mvc;

namespace doan_htttdn.DAO
{
    public class DAO_Product
    {
        private QL_SCN db = new QL_SCN();
        public IEnumerable<PRODUCT> listpd(int page, int pagesize)
        {
            return db.PRODUCTs.OrderByDescending(x => x.IDRobot).ToPagedList(page, pagesize);
        }
        public PRODUCT ViewDetail(string ID)
        {
            return db.PRODUCTs.Where(x => x.IDRobot == ID).SingleOrDefault();
        }

        public IEnumerable<PRODUCT> search(string tk, int page, int pagesize)
        {
            return db.PRODUCTs.Where(x => x.IDRobot.Contains(tk) || x.Name.Contains(tk)).OrderByDescending(x => x.IDRobot).ToPagedList(page, pagesize);
        }

        public IEnumerable<PRODUCT> top3_pd()
        {
            return db.PRODUCTs.Take(3).ToList();
        }

        public bool Update(PRODUCT pd)
        {
            var up = db.PRODUCTs.SingleOrDefault(x => x.IDRobot == pd.IDRobot);
            if (up != null)
            {
                up.Name = pd.Name;
                up.Image = pd.Image;
                up.Number = pd.Number;
                up.Price = pd.Price;
                up.State = pd.State;
                db.SaveChanges();
                return true;

            }
            return false;
        }

    }
}