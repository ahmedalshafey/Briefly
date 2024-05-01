using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Helpers
{
    public class UserClaimTypes
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }

    }
}
