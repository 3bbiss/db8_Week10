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

    }
}
