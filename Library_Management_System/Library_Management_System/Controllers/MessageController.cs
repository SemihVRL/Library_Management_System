using Library_Management_System.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        
        
        Db_Library_ManagementEntities1 db=new Db_Library_ManagementEntities1 ();

        [Authorize]
        public ActionResult MessageIndex()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var degerler = db.TBLMESSAGE.Where(x => x.ALICI == uyemail.ToString()).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(TBLMESSAGE p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.GONDEREN=uyemail.ToString();
            p.TARIH=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESSAGE.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult GoMessage()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var degerler = db.TBLMESSAGE.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(degerler);
        }
    }
}