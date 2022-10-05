using Microsoft.AspNetCore.Mvc;
using BookClubLab.Models;

namespace BookClubLab.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            List<Person> persons = DAL.GetAllPeople();
            return View(persons);
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
                ViewBag.fnameMessage = "First name required";
                isValid = false;
            }
            if (per.lastname == null)
            {
                ViewBag.lnameMessage = "Last name required";
                isValid = false;
            }
            if (per.email == null)
            {
                ViewBag.emailMessage = "Email required";
                isValid = false;
            }
            if (isValid)
            {
                DAL.InsertPerson(per);
                return Redirect("/person");
            }
            else
            {
                List<Person> persons = DAL.GetAllPeople();
                ViewBag.fName = per.firstname;
                ViewBag.lName = per.lastname;
                ViewBag.email = per.email;
                return View("AddForm", persons);
            }
        }


        public IActionResult EditForm(int id)
        {
            //Person per = DAL.GetOnePeople(id);
            //return View(per);
            return View(DAL.GetOnePeople(id));
        }

        public IActionResult SaveChanges(Person per)
        {
            DAL.UpdatePerson(per);
            return Redirect("/person");
        }

        public IActionResult ConfirmDelete(int id)
        {
            Person per = DAL.GetOnePeople(id);
            return View(per);
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePerson(id);
            return Redirect("/person");
        }
    }
}
