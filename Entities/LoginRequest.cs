using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Role Role { get; set; }
    }
}
