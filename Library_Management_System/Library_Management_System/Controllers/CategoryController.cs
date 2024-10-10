using Library_Management_System.Models.Entity;
using Library_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryRepository repo= new CategoryRepository();
        [HttpGet]
        public ActionResult CategoryIndex(string p)
        {
            var degerler = repo.List();
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.CategoryAd.ToLower().Contains(p.ToLower())).ToList();
            }
            return View(degerler);
        }


        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(TBLCATEGORY p)
        {
            repo.Add(p);
            return RedirectToAction("CategoryIndex");
        }

        public ActionResult CategoryDelete(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.Remove(degerler);
            return RedirectToAction("CategoryIndex");
        }

        [HttpGet]
        public ActionResult CategoryFind(int id)
        {
            TBLCATEGORY p = repo.Find(x => x.ID == id);
            return View(p);
        }

        [HttpPost]
        public ActionResult CategoryFind(TBLCATEGORY p)
        {
            var degerler=repo.Find(x=>x.ID == p.ID);
            degerler.ID = p.ID;
            degerler.CategoryAd=p.CategoryAd;
            repo.Update(degerler);
            return RedirectToAction("CategoryIndex");
        }

    }
}