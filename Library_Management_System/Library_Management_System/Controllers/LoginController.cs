using Library_Management_System.Models.Entity;
using Library_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        Db_Library_ManagementEntities1 db = new Db_Library_ManagementEntities1();
        MembersRepository repo = new MembersRepository();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLMEMBERS p)
        {
            var degerler = db.TBLMEMBERS.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);

            if (degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.Mail, false);
                Session["Mail"] = degerler.Mail.ToString();

                //tempdata ile verileri çekme denemesi.
                Session["Name"] = degerler.Name.ToString();
                Session["Surname"] = degerler.Surname.ToString();
                //TempData["Phone"] = degerler.Phone;
                //TempData["School"] = degerler.School.ToString();
                //TempData["Password"] = degerler.Password.ToString();
                return RedirectToAction("StudentPanelIndex", "StudentPanel");
            }

            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}