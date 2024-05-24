using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        public string GenreName { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public ICollection<Book> Book { get; set; }
    }
}
