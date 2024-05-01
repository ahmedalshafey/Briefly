using Briefly.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<PostLike> LikedBy { get; set; } = new List<PostLike>();
        public ICollection<SavedPost> SavedBy { get; set; } = new List<SavedPost>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
