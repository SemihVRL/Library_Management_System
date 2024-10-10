using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult HomePageIndex()
        {
            return View();
        }
    }
}