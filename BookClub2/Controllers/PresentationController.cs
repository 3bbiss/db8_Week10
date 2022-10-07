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
    }
}
