using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Specialized;

namespace BusinessCrudDemo.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=business;Uid=root;Pwd=abc123;");

        // Read all
        public static List<Department> GetAllDepartments()
        {
            return DB.GetAll<Department>().ToList();
        }

        // Read one
        public static Department GetOneDepartment(string id)
        {
            return DB.Get<Department>(id);
        }

        // Create one
        public static Department InsertDepartment(Department dep)
        {
            DB.Insert(dep);
            return dep; // not sure why we have to return dep. Can function return void and just do DB.Insert operation?
        }

        // Delete one
        public static void DeleteDepartment(string id)
        {
            Department dep = new Department() { id = id};
            DB.Delete(dep);
        }

        // Update one
        public static void UpdateDepartment(Department dep)
        {
            DB.Update(dep);
        }

    }
}
