﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Net.Mail;
using doan_htttdn.FF;

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
            smtp.Credentials = new NetworkCredential("", "");
            var mail = new MailMessage(".com", to)
            {
                Subject = subject,
                Body = link,
                IsBodyHtml = true,
            };
            smtp.Send(mail);
            // thôi vâ cai úer cũng ok rô , h chơ cái admin

        }

    }
}