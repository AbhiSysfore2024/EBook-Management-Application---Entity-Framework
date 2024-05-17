using System.ComponentModel.DataAnnotations;

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

    }
}
