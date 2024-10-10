using Library_Management_System.Models.Entity;
using Library_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Library_Management_System.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members

        MembersRepository repo = new MembersRepository();
        public ActionResult MembersIndex(int sayfa=1)
        {
            var degerler = repo.List().ToPagedList(sayfa, 4);
            return View(degerler);
        }


        [HttpGet]
        public ActionResult MembersAdd()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MembersAdd(TBLMEMBERS p)
        {
            if (!ModelState.IsValid)
            {
                return View("MembersAdd");
            }
            repo.Add(p);
            return RedirectToAction("MembersIndex");
        }

        public ActionResult MembersDelete(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.Remove(degerler);
            return RedirectToAction("MembersIndex");
        }


        [HttpGet]
        public ActionResult MembersFind(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult MembersFind(TBLMEMBERS p)
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.ID = p.ID;
            degerler.Name = p.Name;
            degerler.Surname = p.Surname;
            degerler.Mail = p.Mail;
            degerler.Username = p.Username;
            degerler.Password = p.Password;
            degerler.Photo = p.Photo;
            degerler.Phone=p.Phone;
            degerler.School = p.School;
            repo.Update(degerler);
            return RedirectToAction("MembersIndex");
        }

    }
}