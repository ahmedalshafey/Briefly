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
    public  class RssSubscirptionConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<RssSubscription>
    {
        public void Configure(EntityTypeBuilder<RssSubscription> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RssId });
            builder.HasOne(x => x.User).WithMany(x => x.RssSubscriptions).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Rss).WithMany(x => x.SubscribedBy).HasForeignKey(x => x.RssId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
