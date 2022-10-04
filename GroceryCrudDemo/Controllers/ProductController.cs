using GroceryCrudDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryCrudDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            //List<Product> prods = DAL.GetAllProducts();
            return View(DAL.GetAllProducts());
        }

        // Delete a product
        // Won't return a View(), but will redirect instead
        // back to the index /product
        public IActionResult Delete(int id)
        {
            DAL.DeleteProduct(id);
            return Redirect("/product");
        }

        // Display detail for a single product
        public IActionResult Detail(int id)
        {
            return View(DAL.GetOneProduct(id));
        }

        // Add a product requires two routes
        // 1. A route to send form to browser
        // 2. A route browser calls when form is submitted
        public IActionResult AddForm()
        {
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult Add(Product prod)
        {
            // Validation: if a field is blank, set a
            // message for it and send user back to form

            bool isValid = true;
            if (prod.name == null)
            {
                ViewBag.NameMessage = "Name required";
                isValid = false;
            }
            if (prod.description == null)
            {
                ViewBag.DescMessage = "Desc. required";
                isValid = false;
            }
            if (prod.price <= 0)
            {
                ViewBag.PriceMessage = "Price invalid";
                isValid = false;
            }
            if (isValid)
            {
                DAL.InsertProduct(prod);
                return Redirect("/product");
            }
            else
            {
                List<Category> cats = DAL.GetAllCategories();
                ViewBag.Name = prod.name;
                ViewBag.Description = prod.description;
                ViewBag.Price = prod.price;
                ViewBag.Inventory = prod.inventory;
                return View("AddForm", cats);
            }

        }

        // Edit a product needs two routes
        // 1. A route to send (prepopulated) form to browser
        // 2. A route that does the update and redirects 
        // back to index
        public IActionResult EditForm(int id)
        {
            //Product prod = DAL.GetOneProduct(id);
            //ViewBag.Categories = DAL.GetAllCategories();
            ViewData["categories"] = DAL.GetAllCategories();
            return View(DAL.GetOneProduct(id));
        }

        public IActionResult SaveChanges(Product prod)
        {
            DAL.UpdateProduct(prod);
            return Redirect("/product");
        }

    }
}
