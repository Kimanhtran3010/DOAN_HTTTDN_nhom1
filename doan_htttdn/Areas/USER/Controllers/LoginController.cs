using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.Areas.USER.Models;


namespace doan_htttdn.Areas.USER.Controllers
{
    public class LoginController : Controller
    {
        // GET: USER/Login
        public ActionResult Index()
        {
            
            return View( );
        }

       public async Task<ActionResult> Login()
        {
            string usernamecookies = System.Web.HttpContext.Current.User.Identity.Name;
            if (!String.IsNullOrEmpty(usernamecookies))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new Admin_Article());
        }

        
    }
}