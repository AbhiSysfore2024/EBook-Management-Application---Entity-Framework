using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class AuthorName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
