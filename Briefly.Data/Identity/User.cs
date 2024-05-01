using Briefly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Identity
{
    public class User:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Code { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public ICollection<UserFollowing> Followers { get; set; } = new HashSet<UserFollowing>();
        public ICollection<UserFollowing> Following { get; set; } = new HashSet<UserFollowing>();

        public ICollection<PostLike> LikedPosts { get; set; } = new HashSet<PostLike>();

        public ICollection<SavedPost> PostsSaved { get; set; } = new HashSet<SavedPost>();
        public ICollection<SavedArticle> ArticleSaved { get; set; } = new HashSet<SavedArticle>();

        public ICollection<RssSubscription> RssSubscriptions { get; set; } = new HashSet<RssSubscription>();

        public virtual ICollection<UserRefreshToken>? RefreshTokens { get; set; }

    }
}