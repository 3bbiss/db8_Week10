using Dapper.Contrib.Extensions;
namespace BookClubLab.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }
}
