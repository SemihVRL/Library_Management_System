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
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeRepository repo = new EmployeeRepository();
        public ActionResult EmployeeIndex(int sayfa=1)
        {
            var degerler = repo.List().ToPagedList(sayfa,4);
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeAdd(TBLEMPLOYEE p)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeAdd");
            }
           repo.Add(p);
           return RedirectToAction("EmployeeIndex");
        }

        public ActionResult EmployeeDelete(int id)
        {
            var degerler=repo.Find(x=>x.ID==id);
            repo.Remove(degerler);
            return RedirectToAction("EmployeeIndex");
        }
        [HttpGet]
        public ActionResult EmployeeFind(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult EmployeeFind(TBLEMPLOYEE p)
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.ID = p.ID;
            degerler.Name = p.Name;
            degerler.Surname = p.Surname;
            repo.Update(degerler);
            return RedirectToAction("EmployeeIndex");
        }
    }

}