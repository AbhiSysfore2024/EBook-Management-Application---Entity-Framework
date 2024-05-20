using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DTOAuthor
    {
        public AuthorName Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
    }
}
