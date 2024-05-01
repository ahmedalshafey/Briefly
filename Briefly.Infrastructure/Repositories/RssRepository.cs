using Briefly.Data.Entities;
using Briefly.Infrastructure.Context;
using Briefly.Infrastructure.IRepositoties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.Repositories
{
    public class RssRepository : GenericRepository<RSS>, IRssRepository
    {
        public RssRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<RSS> AddRssAsync(RSS rss)
        {
            var result = await _dbset.AddAsync(rss);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<RSS>> GetRssSubscribtions(string userId)
        {
            var Userid = int.Parse(userId);
            var res = await _dbset
            .Include(x => x.SubscribedBy)
            .Where(x => x.SubscribedBy.Any(s => s.UserId == Userid))
            .ToListAsync();
            return res;
        }
    }
}
