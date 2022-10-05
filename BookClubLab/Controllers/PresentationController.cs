using Microsoft.AspNetCore.Mvc;
using BookClubLab.Models;

namespace BookClubLab.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            return View(DAL.GetAllPresentations());
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePresentation(id);
            return Redirect("/presentation");
        }

        public IActionResult Detail(int id)
        {
            return View(DAL.GetOnePresentation(id));
        }

        public IActionResult AddForm()
        {
            List<Person> people = DAL.GetAllPeople();
            return View(people);
        }

        public IActionResult Add(Presentation pres)
        {
            bool isValid = true;
            if (pres.presentationDate == null)
            {
                ViewBag.dateMessage = "Please enter a date";
                isValid = false;
            }
            if (pres.bookTitle == null)
            {
                ViewBag.bookTitleMessage = "Enter a title";
                isValid = false;
            }
            if (pres.bookAuthor == null)
            {
                ViewBag.bookAuthorMessage = "Enter an author";
                isValid = false;
            }
            if (pres.genre == null)
            {
                ViewBag.genreMessage = "Enter a genre";
                isValid = false;
            }
            if (isValid)
            {
                DAL.InsertPresentation(pres);
                return Redirect("/presentation");
            }
            else
            {
                List<Person> people = DAL.GetAllPeople();
                ViewBag.presentationDate = pres.presentationDate;
                ViewBag.bookTitle = pres.bookTitle;
                ViewBag.bookAuthor = pres.bookAuthor;
                ViewBag.genre = pres.genre;
                return View("AddForm", people);
            }
        }


    }
}
