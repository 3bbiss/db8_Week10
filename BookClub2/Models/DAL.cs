using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Net.NetworkInformation;

namespace BookClub2.Models
{
    public class DAL
    {
        public static MySqlConnection DB;

        public static List<Person> GetAllPeople()
        {
            return DB.GetAll<Person>().ToList();
        }

        public static Person GetOnePerson(int id)
        {
            return DB.Get<Person>(id);
        }

        public static Person InsertPerson(Person per)
        {
            DB.Insert(per);
            return per;
        }

        public static void DeletePerson(int id)
        {
            DB.Execute("delete from presentation where personid=@personid", new {personid = id});
            Person per = new Person() { id = id };
            DB.Delete(per);
        }

        public static void UpdatePerson(Person per)
        {
            DB.Update(per);
        }


        public static List<Presentation> GetAllPresentation()
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








/*
GetAllPeople: Returns a list of Person instances; no parameters
GetOnePerson: Returns a single Person instance; parameter is an ID
InsertPerson: Returns a Person instance; parameter is a Person instance with all but ID filled in
DeletePerson: Returns void; parameter is the ID of the Person to delete
UpdatePerson: Returns void; parameter is the Person instance to update 
 */