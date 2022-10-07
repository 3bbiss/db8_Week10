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




    }
}
