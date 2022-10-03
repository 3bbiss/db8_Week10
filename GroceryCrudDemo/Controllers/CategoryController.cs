using GroceryCrudDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryCrudDemo.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Category cat)
        {
            DAL.InsertCategory(cat);
            return Redirect("/category");
        }
    }
}
