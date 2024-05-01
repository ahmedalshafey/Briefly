using Briefly.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.Configurationz
{
    public class ArticleConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.RSS)
                   .WithMany(x => x.Articles)
                   .HasForeignKey(x => x.RSSId).OnDelete(DeleteBehavior.Restrict);
            
        }
        
    }
}
