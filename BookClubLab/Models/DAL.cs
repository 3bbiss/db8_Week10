using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Net.Http.Headers;

namespace BookClubLab.Models
{
    public class DAL
    {
        //public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=abc123;");
        public static MySqlConnection DB;


        public static List<Person> GetAllPeople()
        {
            return DB.GetAll<Person>().ToList();
        }

        public static Person GetOnePeople(int id)
        {
            return DB.Get<Person>(id);
        }

        public static Person InsertPerson(Person per)
        {
            DB.Insert<Person>(per);
            return per;
        }


        public static void DeletePerson(int id)
        {
            DB.Execute("delete from presentation where personid=@personid", new {personid = id});

            Person per = new Person() { id = id};
            DB.Delete(per);
        }

        public static void UpdatePerson(Person per)
        {
            DB.Update<Person>(per);
        }



        public static List<Presentation> GetAllPresentations()
        {
            return DB.GetAll<Presentation>().ToList();
        }

        public static Presentation GetOnePresentation(int id)
        {
            return DB.Get<Presentation>(id);
        }

        public static Presentation InsertPresentation(Presentation pres)
        {
            DB.Insert(pres);
            return pres;
        }

        public static void DeletePresentation(int id)
        {
            Presentation pres = new Presentation() { id = id };
            DB.Delete(pres);
        }

        public static void UpdatePresentation(Presentation pres)
        {
            DB.Update(pres);
        }
    }
}
