using Library_Management_System.Models.Entity;
using Library_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class BookActionController : Controller
    {
        // GET: BookAction
        BookAction repo = new BookAction();

        Db_Library_ManagementEntities1 db = new Db_Library_ManagementEntities1();

        // ÖDÜNÇ VERME İŞLEMİ
        [HttpGet]
        public ActionResult GiveBookIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GiveBookIndex(TBLACTION p)
        {

            var degerler=db.TBLACTION.Add(p);
            degerler.Durum2 = false;
            db.SaveChanges();

            return RedirectToAction("GiveBookIndex");
        }
        public ActionResult TakeBookIndex()
        {

            var degerler = db.TBLACTION.Where(x=>x.Durum2==false).ToList();
            return View(degerler);
        }

        public ActionResult TakeBook(TBLACTION p)
        {
            var degerler=db.TBLACTION.Find(p.ID);
            DateTime d1 = DateTime.Parse(degerler.ReturnDate.ToString());

            DateTime d2=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;

            ViewBag.dgr = d3.TotalDays;
            return View("TakeBook", degerler);

        }

        public ActionResult TakeBookUpdate(TBLACTION p)
        {
            var degerler = db.TBLACTION.Find(p.ID);
            degerler.GetirdigiTarih = p.GetirdigiTarih;
            degerler.Durum2 = true;
            db.SaveChanges();
            return RedirectToAction("TakeBookIndex");

        }
    }
}