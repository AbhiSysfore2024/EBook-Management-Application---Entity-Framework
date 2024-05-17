using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BookModel
    {
        [Key]
        public Guid BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ISBN { get; set; }
        public DateTime Publication_Date { get; set; }
        public float Price { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public float AvgRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public int BookGenre { get; set; }
        public bool IsAvailable { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
