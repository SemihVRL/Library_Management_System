using Library_Management_System.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        Db_Library_ManagementEntities1 db=new Db_Library_ManagementEntities1 ();
        public ActionResult OperationIndex()
        {
            var degerler=db.TBLACTION.Where(x=>x.Durum2==true).ToList();
            return View(degerler);
        }
    }
}