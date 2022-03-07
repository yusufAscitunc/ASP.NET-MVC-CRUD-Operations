using MvcEF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEF_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();

            DatabaseContext db = new DatabaseContext();
            List<Person> people = db.People.ToList();
            vm.People = db.People.ToList();
            vm.Addresses = db.Addresses.ToList();
            return View(vm);
        }
    }
}