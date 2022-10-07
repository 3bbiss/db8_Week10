using Microsoft.AspNetCore.Mvc;
using BookClub2.Models;

namespace BookClub2.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            List<Presentation> presentations = DAL.GetAllPresentation();
            return View(presentations);
        }

        public IActionResult Detail(int id)
        {
            return View(DAL.GetOnePresentation(id));
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePresentation(id);
            return Redirect("/presentation");
        }

        public IActionResult AddForm()
        {
            List<Person> people = DAL.GetAllPeople();
            return View(people);
        }

        public IActionResult Add(Presentation pres)
        {
            bool isValid = true;

            if (pres.presentationdate == null)
            {
                isValid = false;
                ViewBag.presentationdateMessage = "Enter a date";
            }
            if (pres.booktitle == null)
            {
                isValid = false;
                ViewBag.booktitleMessage = "Enter a title";
            }
            if (pres.bookauthor == null)
            {
                isValid = false;
                ViewBag.bookauthorMessage = "Enter an author";
            }
            if (pres.genre == null)
            {
                isValid = false;
                ViewBag.genreMessage = "Enter a genre";
            }
            if (isValid)
            {
                DAL.InsertPresentation(pres);
                return Redirect("/presentation");
            }
            else
            {
                List<Person> people = DAL.GetAllPeople();
                ViewBag.presentationdate = pres.presentationdate;
                ViewBag.booktitle = pres.booktitle;
                ViewBag.bookauthor = pres.bookauthor;
                ViewBag.genre = pres.genre;
                return View("AddForm", people);
            }
        }


        public IActionResult EditForm(int id)
        {
            ViewData["people"] = DAL.GetAllPeople();
            return View(DAL.GetOnePresentation(id));   
        }

        public IActionResult SaveChanges(Presentation pres)
        {
            DAL.UpdatePresentation(pres);
            return Redirect("/presentation");
        }

    }
}
