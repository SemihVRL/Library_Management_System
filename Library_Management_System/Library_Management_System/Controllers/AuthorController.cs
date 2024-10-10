using Library_Management_System.Models.Entity;
using Library_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        AuthorRepository repo=new AuthorRepository();
        [HttpGet]   
        public ActionResult AuthorIndex(string p)
        {
            var degerler = repo.List();
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.Name.ToLower().Contains(p.ToLower())).ToList();
            }
           
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AuthorAdd()
        {
            return View();  
        }
        
        [HttpPost]
        public ActionResult AuthorAdd(TBLAUTHOR p)
        {
            repo.Add(p);
           return RedirectToAction("AuthorIndex");
        }

        public ActionResult AuthorDelete(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.Remove(degerler);
            return RedirectToAction("AuthorIndex");
        }

        [HttpGet]
        public ActionResult AuthorFind(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult AuthorFind(TBLAUTHOR p)
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.ID= p.ID;
            degerler.Name= p.Name;
            degerler.Surname= p.Surname;
            degerler.Detail= p.Detail;
            repo.Update(degerler);
            return RedirectToAction("AuthorIndex");

        }
        
    }
}