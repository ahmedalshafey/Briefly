using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Helpers
{
    public class EmailSetting
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string FromEmail { get; set; }
        public string Password { get; set; }

    }
}
