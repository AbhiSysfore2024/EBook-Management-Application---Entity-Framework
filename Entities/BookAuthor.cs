using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BookAuthor
    {
        [Column(Order = 0)]
        public Guid BookId { get; set; }

        [Column(Order = 1)]
        public Guid AuthorId { get; set; }

        public virtual BookModel Book { get; set; }

        public virtual AuthorModel Author { get; set; }
    }

}
