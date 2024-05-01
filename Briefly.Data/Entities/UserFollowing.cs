using Briefly.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Entities
{
    public class UserFollowing
    {
        public int FollowerId { get; set; }
        public User Follower { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
