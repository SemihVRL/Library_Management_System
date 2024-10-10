using Library_Management_System.Models.Classes;
using Library_Management_System.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store

        Db_Library_ManagementEntities1 db=new Db_Library_ManagementEntities1();
        [HttpGet]
        public ActionResult StoreIndex()
        {
            LibraryEnumerable library=new LibraryEnumerable();
            library.Books=db.TBLBOOK.ToList();
            library.Abouts=db.TBLABOUT.ToList();
            return View(library);
        
            //var degerler=db.TBLBOOK.ToList();    
            //return View(degerler);
        }
        [HttpPost]
        public ActionResult StoreIndex(TBLCONTACT p)
        {
            db.TBLCONTACT.Add(p);
            db.SaveChanges();
            return RedirectToAction("StoreIndex");
        }
    }
}