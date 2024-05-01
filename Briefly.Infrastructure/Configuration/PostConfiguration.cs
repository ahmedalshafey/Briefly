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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Posts)
                   .HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
