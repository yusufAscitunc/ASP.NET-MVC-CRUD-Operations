using MvcEF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEF_CodeFirst.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HomePage(Person person)
        {
            DatabaseContext db = new DatabaseContext();
            db.People.Add(person);

            int res = db.SaveChanges();

            if (res > 0)
            {
                ViewBag.msg = "added";
                ViewBag.type = "success";
            }
            else
            {
                ViewBag.msg = "error";
                ViewBag.type = "danger";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            Person p = new Person();

            DatabaseContext db = new DatabaseContext();
            p = db.People.Where(x => x.Id == id).FirstOrDefault();

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Person person, int id)
        {
            Person p = new Person();

            DatabaseContext db = new DatabaseContext();
            p = db.People.Where(x => x.Id == id).FirstOrDefault();

            p.Name = person.Name;
            p.Surname = person.Surname;
            p.Age = person.Age;

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? id)
        {

            Person p = new Person();
            DatabaseContext db = new DatabaseContext();

            if (id != null)
            {
                p = db.People.Where(x => x.Id == id).FirstOrDefault();
            }


            return View(p);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteP(int? id)
        {

            Person p = new Person();
            DatabaseContext db = new DatabaseContext();
            
            if (id != null)
            {
                p = db.People.Where(x => x.Id == id).FirstOrDefault();
                db.People.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}