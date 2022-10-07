using Microsoft.AspNetCore.Mvc;
using BookClub2.Models;

namespace BookClub2.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            List<Person> people = DAL.GetAllPeople();
            return View(people);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Person per)
        {
            bool isValid = true;

            if (per.firstname == null)
            {
                isValid = false;
                ViewBag.firstnameMessage = "Enter first name";
            }
            if (per.lastname == null)
            {
                isValid = false;
                ViewBag.lastnameMessage = "Enter last name";
            }
            if (per.email == null)
            {
                isValid = false;
                ViewBag.emailMessage = "Enter email";
            }
            if (isValid)
            {
                DAL.InsertPerson(per);
                return Redirect("/person");
            }
            else
            {
                //List<Person> people = DAL.GetAllPeople();
                ViewBag.firstname = per.firstname;
                ViewBag.lastname = per.lastname;
                ViewBag.email = per.email;
                return View("AddForm");
            }
        }

    }
}
