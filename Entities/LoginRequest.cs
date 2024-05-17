using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Keyless]
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Role Role { get; set; }
    }
}
