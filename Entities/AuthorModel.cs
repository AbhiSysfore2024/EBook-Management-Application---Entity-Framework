using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Entities
{
    public class AuthorModel
    {
        [Key]
        public Guid AuthorID { get; set; }
        public AuthorName Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<BookAuthor> BookAuthor { get; set; }

        public AuthorModel()
        {

        }

        public AuthorModel(DTOAuthor author)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            AuthorID = Guid.NewGuid();
            this.Name = (AuthorName)author.Name;
            this.Biography = author.Biography;
            this.BirthDate = author.BirthDate;
            this.Country = author.Country;
        }
    }
}
