using Briefly.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Service.Interfaces.Rss
{
    public interface IRssService
    {
        Task<string> CreateUserRss(string userId, string url);
        Task<string> RssUserSubscribe(string userId,int rssId);
        Task<string> RssUnUserSubscribe(string userId, int rssId);
        Task<List<RSS>> GetAllSubscribedRss(string userId);
        Task<List<RSS>> GetAllRss(string userId);
        Task<RSS> GetRssById(int rssId);
    }
}
