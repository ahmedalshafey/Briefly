using Briefly.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Entities
{
    public class RssSubscription
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RssId { get; set; }
        public RSS Rss { get; set; }
        public DateTime DateSubscribed { get; set; } = DateTime.Now;

    }
}
