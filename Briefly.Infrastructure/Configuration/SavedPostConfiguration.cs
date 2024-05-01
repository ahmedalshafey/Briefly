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
    public  class SavedPostConfiguration : IEntityTypeConfiguration<SavedPost>
    {
        public void Configure(EntityTypeBuilder<SavedPost> builder)
        {
            builder.HasKey(x => new { x.UserId, x.PostId });
            builder.HasOne(x => x.User).WithMany(x => x.PostsSaved).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Post).WithMany(x => x.SavedBy).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
