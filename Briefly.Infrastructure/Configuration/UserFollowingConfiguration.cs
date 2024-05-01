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
    public class UserFollowingConfiguration : IEntityTypeConfiguration<UserFollowing>
    {
        public void Configure(EntityTypeBuilder<UserFollowing> builder)
        {
            builder.HasKey(x => new { x.FollowerId, x.UserId });
            builder.HasOne(x => x.Follower).WithMany(x => x.Following).HasForeignKey(x => x.FollowerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(x => x.Followers).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict); // Following
        }
    }
}
