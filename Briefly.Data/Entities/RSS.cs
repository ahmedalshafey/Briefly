using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Entities
{
    public class RSS
    { 
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Link { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }

        // Navigation property for Category
        [BindNever]
        public virtual RssCategory Rsscategory { get; set; }
        [BindNever]
        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
        [BindNever]
        public ICollection<RssSubscription> SubscribedBy { get; set; } = new HashSet<RssSubscription>();
       
    }
}
