using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Data.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Link { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
        public string? Summarized { get; set; }

        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RSSId { get; set; }
        public RSS RSS { get; set; }


    }
}
