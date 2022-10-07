using Dapper.Contrib.Extensions;
namespace BookClub2.Models
{
    [Table("presentation")]
    public class Presentation
    {
        [Key]
        public int id { get; set; }
        public int personid { get; set; }
        public DateTime presentationdate { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
    }
}
