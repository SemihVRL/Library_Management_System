using Library_Management_System.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
   
    public class StudentPanelController : Controller
    {
        // GET: StudentPanel
        Db_Library_ManagementEntities1 db = new Db_Library_ManagementEntities1();

       

        [HttpGet]
        public ActionResult StudentPanelIndex()
        {
            var degerler1 = (string)Session["Mail"];
            var uye1 = db.TBLMEMBERS.FirstOrDefault(x => x.Mail == degerler1);
            return View(uye1);
        }
        [HttpPost]
        public ActionResult StudentPanelIndex(TBLMEMBERS p)
        {
            var degerler = (string)Session["Mail"];
            var uye = db.TBLMEMBERS.FirstOrDefault(x => x.Mail == degerler);
            uye.Password = p.Password;
            db.SaveChanges();
            return View();
        }

        public ActionResult Books()
        {
            var kullanici = (string)Session["Mail"];
            var id=db.TBLMEMBERS.Where(x=>x.Mail==kullanici.ToString()).Select(z=>z.ID).FirstOrDefault();

            var degerler=db.TBLACTION.Where(x=>x.Member==id).ToList();

            return View(degerler);
        }
    }
}