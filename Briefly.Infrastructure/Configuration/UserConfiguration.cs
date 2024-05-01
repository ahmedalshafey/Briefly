using Briefly.Data.Entities;
using Briefly.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.Configuration
{
    public class UserConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
                builder.HasMany(u => u.ArticleSaved)
                    .WithOne(sa => sa.User)
                    .HasForeignKey(sa => sa.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.PostsSaved)
                .WithOne(sp => sp.User)
                .HasForeignKey(sp => sp.UserId).OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(u => u.LikedPosts)
                    .WithOne(pl => pl.User)
                    .HasForeignKey(pl => pl.UserId).OnDelete(DeleteBehavior.Restrict);

               

            builder.HasMany(u => u.RssSubscriptions)
                       .WithOne(rss => rss.User)
                       .HasForeignKey(rss => rss.UserId).OnDelete(DeleteBehavior.Restrict);

            }
        }

    
}
