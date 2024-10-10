using Library_Management_System.Models.Entity;
using Library_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        Db_Library_ManagementEntities1 db=new Db_Library_ManagementEntities1();
        MembersRepository repository=new MembersRepository();
        [HttpGet]   
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(TBLMEMBERS p)
        {
           if (!ModelState.IsValid)
            {
                return View("Register");
            }
            repository.Add(p);
            return View();
        }
    }
}