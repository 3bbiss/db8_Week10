using Microsoft.AspNetCore.Mvc;
using BusinessCrudDemo.Models;

namespace BusinessCrudDemo.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            List<Department> dep = DAL.GetAllDepartments();
            return View(dep);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Department dep)
        {
            DAL.InsertDepartment(dep);
            return Redirect("/department");
        }

        public IActionResult Delete(string id)
        {
            DAL.DeleteDepartment(id);
            return Redirect("/department");
        }

        public IActionResult Detail(string id)
        {
            //Department dep = DAL.GetOneDepartment(id);
            //return View(id);
            return View(DAL.GetOneDepartment(id));
        }

        public IActionResult EditForm(string id) // why we need to pass id again? can't remember...
        {
            Department dep = DAL.GetOneDepartment(id);
            return View(dep);
        }

        public IActionResult SaveChanges(Department dep)
        {
            DAL.UpdateDepartment(dep);
            return Redirect("/department");
        }
    }
}
