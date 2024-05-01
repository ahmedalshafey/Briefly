using Briefly.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.IRepositoties
{
    public interface IRssRepository:IGenericRepository<RSS>
    {
        Task<RSS> AddRssAsync(RSS rss);
        Task<List<RSS>> GetRssSubscribtions(string userId);
    }
}
