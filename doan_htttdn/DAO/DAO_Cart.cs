using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Net.Mail;
using doan_htttdn.FF;
using PagedList;
using PagedList.Mvc;

namespace doan_htttdn.DAO
{
    public class DAO_Cart
    {
        QL_SCN db = new QL_SCN();
        public int get_id(FF.ORDER od)
        {
            db.ORDERS.Add(od);
            db.SaveChanges();
            return od.IDOrders;
        }

        public ORDER getby_id(int id)
        {
            return db.ORDERS.Where(x => x.IDOrders == id).SingleOrDefault();
        }
        public void sendmail(string subject, string url, string to)
        {
            // 
            string link = "Vui lòng xác thực tài khoản của bạn .<br> Nhấn vào đây : <a href=\"" + url + "\">here</a>";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("testdemo2105@gmail.com", "duy12345678");
            var mail = new MailMessage("testdemo2105@gmail.com", to)
            {
                Subject = subject,
                Body = link,
                IsBodyHtml = true,
            };
            smtp.Send(mail);
            // thôi vâ cai úer cũng ok rô , h chơ cái admin

        }

        public IEnumerable<ORDER> listod(int page, int pagesize)
        {
            return db.ORDERS.OrderByDescending(x => x.IDOrders).ToPagedList(page, pagesize);
        }
        public IEnumerable<ORDER> search(string tk, int page, int pagesize)
        {
            var id = Convert.ToInt32(tk);
            return db.ORDERS.Where(x => x.IDOrders == id || x.Email == tk).OrderByDescending(x => x.IDOrders).ToPagedList(page, pagesize);
        }

        public IEnumerable<ORDER> search_date(DateTime? nkq, int page, int pagesize)
        {

            return db.ORDERS.Where(x => x.DATE == nkq).OrderByDescending(x => x.IDOrders).ToPagedList(page, pagesize);
        }
    }
}