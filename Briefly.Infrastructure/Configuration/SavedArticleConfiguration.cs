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
    public class SavedArticleConfiguration : IEntityTypeConfiguration<SavedArticle>
    {
        public void Configure(EntityTypeBuilder<SavedArticle> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ArticleId });
            builder.HasOne(x => x.User).WithMany(x => x.ArticleSaved).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
