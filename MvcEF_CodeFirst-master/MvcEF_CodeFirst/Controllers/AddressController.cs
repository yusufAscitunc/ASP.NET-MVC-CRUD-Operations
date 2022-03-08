using MvcEF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEF_CodeFirst.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Address()
        {
            DatabaseContext db = new DatabaseContext();
            //List<Person> people = db.People.ToList();
            //List<SelectListItem> items = new List<SelectListItem>();

            List<SelectListItem> items =
                (from person in db.People.ToList()
                 select new SelectListItem()
                 {
                     Text = person.Name + " " + person.Surname,
                     Value = person.Id.ToString()
                 }
                ).ToList();

            //foreach (var person in people)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = person.Name + " " + person.Surname;
            //    item.Value = person.Id.ToString();
            //    items.Add(item);
            //}
            TempData["people"] = items;
            ViewBag.people = items;
            

            return View();
        }

        [HttpPost]
        public ActionResult Address(Address address)
        {   
            DatabaseContext db = new DatabaseContext();

            Person people = db.People.Where(x => x.Id == address.Person.Id).FirstOrDefault();
            address.Person = people;
            db.Addresses.Add(address);

            int res = db.SaveChanges();
            if (res > 0)
            {
                ViewBag.msg = "Added";
            }
            else ViewBag.msg = "Error";

            ViewBag.people = TempData["people"];

            return View();
        }

        public ActionResult Edit(int? addressId)
        {
            DatabaseContext db = new DatabaseContext();
            Address a = new Address();

            if (addressId != null)
            {
                a = db.Addresses.Where(x => x.Id == addressId).FirstOrDefault();
            }

            List<SelectListItem> items =
                (from person in db.People.ToList()
                 select new SelectListItem()
                 {
                     Text = person.Name + " " + person.Surname,
                     Value = person.Id.ToString()
                 }
                ).ToList();
            ViewBag.people = items;
            TempData["people"] = items;
            


            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(Address newInfo, int? addressId)
        {
            DatabaseContext db = new DatabaseContext();
            Address a = new Address();

            if (addressId != null)
            {
                a = db.Addresses.Where(x => x.Id == addressId).First();
            a.MailingAddress = newInfo.MailingAddress;

            int result = db.SaveChanges();

            if (result > 0) {
                ViewBag.Message = "Address saved.";
                ViewBag.type = "success"; 
                }
                else { 
                ViewBag.Message = "An error occured.";
                ViewBag.type = "danger";
                }
            }


            ViewBag.people = TempData["people"];

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? aId)
        {

            Address a = new Address();
            DatabaseContext db = new DatabaseContext();

            if (aId != null)
            {
                a = db.Addresses.Where(x => x.Id == aId).FirstOrDefault();
            }


            return View(a);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteA(int? aId)
        {

            Address a = new Address();
            DatabaseContext db = new DatabaseContext();

            if (aId != null)
            {
                a = db.Addresses.Where(x => x.Id == aId).FirstOrDefault();
                db.Addresses.Remove(a);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }


    }
}