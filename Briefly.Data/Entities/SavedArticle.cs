using Briefly.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Entities
{
    public class SavedArticle
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
