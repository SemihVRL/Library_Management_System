using Library_Management_System.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        Db_Library_ManagementEntities1 db=new Db_Library_ManagementEntities1();

        [HttpGet]
        public ActionResult AdminPanelIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminPanelIndex(TBLADMİN p)
        {
            var degerler = db.TBLADMİN.FirstOrDefault(x => x.Users == p.Users && x.Password == p.Password);
            if (degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.Users, false);
                Session["Users"] = degerler.Users.ToString();

                return RedirectToAction("HomePageIndex", "HomePage");
            }
            else

            {
                return RedirectToAction("AdminPanelIndex", "AdminPanel");

            }
        }
    }
}
