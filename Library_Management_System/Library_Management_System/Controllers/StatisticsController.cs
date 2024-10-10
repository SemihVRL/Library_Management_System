using Library_Management_System.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Db_Library_ManagementEntities1 db= new Db_Library_ManagementEntities1();
        public ActionResult StatisticsIndex()
        {
            var deger1=db.TBLMEMBERS.Count();
            ViewBag.dgr = deger1;

            var deger2=db.TBLBOOK.Count();
            ViewBag.dgr2 = deger2;

            var deger3 = db.TBLACTION.Where(x => x.Durum2 == false).Count();
            ViewBag.dgr3 = deger3;

            var deger4 = db.TBLPUNISHMENT.Sum(x => x.Money);
            ViewBag.dgr4 = deger4;
            return View();
        }

        public ActionResult HavaIndex()
        {
            return View();
        }

        public ActionResult HavaCards()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }


        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength>0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/webhava/resimler/"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
              
            }

            return RedirectToAction("Gallery");
        }
    }
}