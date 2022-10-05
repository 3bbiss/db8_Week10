using Dapper.Contrib.Extensions;
namespace BookClubLab.Models
{
    [Table("presentation")]
    public class Presentation
    {
        [Key]
        public int id { get; set; }
        public int personid { get; set; }
        public DateTime presentationDate { get; set; }
        public string bookTitle { get; set; }
        public string bookAuthor { get; set; }
        public string genre { get; set; }
    }
}
