using Library_Management_System.Models.Entity;
using Library_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookRepository repo = new BookRepository();
        Db_Library_ManagementEntities1 db = new Db_Library_ManagementEntities1();
        [HttpGet]
        public ActionResult BookIndex(string p)
        {
            var degerler = db.TBLBOOK.ToList();

            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
           
            return View(degerler);
        }

        [HttpGet]
        public ActionResult BookAdd()
        {

            List<SelectListItem> deger1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryAd,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]

        public ActionResult BookAdd(TBLBOOK p)
        {
            var deger2 = db.TBLCATEGORY.Where(x => x.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var deger3 = db.TBLAUTHOR.Where(y => y.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            p.TBLCATEGORY = deger2;
            p.TBLAUTHOR = deger3;
            db.TBLBOOK.Add(p);
            db.SaveChanges();
            return RedirectToAction("BookIndex");
        }

        public ActionResult BookDelete(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.Remove(degerler);
            return RedirectToAction("BookIndex");
        }

        [HttpGet]
        public ActionResult BookFind(int id)
        {
            var degerler = repo.Find(x => x.ID == id);

            List<SelectListItem> deger1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryAd,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View(degerler);
        }

        [HttpPost]

        public ActionResult BookFind(TBLBOOK p)
        {
            var degerler = db.TBLBOOK.Find(p.ID);
            degerler.ID = p.ID;
            degerler.Name = p.Name;
            degerler.EditionYear = p.EditionYear;
            degerler.PublishingHouse = p.PublishingHouse;
            degerler.Page = p.Page;
            var category = db.TBLCATEGORY.Where(x => x.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var author = db.TBLAUTHOR.Where(x => x.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            degerler.Category = category.ID;
            degerler.Author = author.ID;
            degerler.Status = true;
            db.SaveChanges();
            return RedirectToAction("BookIndex");
        }
    }
}