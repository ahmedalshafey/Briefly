using Briefly.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.Configuration
{
    public class RssCategoryConfiguration : IEntityTypeConfiguration<RssCategory>
    {
        public void Configure(EntityTypeBuilder<RssCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(c => c.RssFeeds)
               .WithOne(r => r.Rsscategory)
               .HasForeignKey(r => r.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}