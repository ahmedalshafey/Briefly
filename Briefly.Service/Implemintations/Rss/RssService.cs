using Briefly.Data.Identity;
using Briefly.Infrastructure.Context;
using Briefly.Infrastructure.IRepositoties;
using Briefly.Infrastructure.Repositories;
using Briefly.Service.Interfaces.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Briefly.Data.Entities;
using CodeHollow.FeedReader;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Briefly.Service.Implemintations.Rss
{
    public class RssService : IRssService
    {
        private readonly IRssRepository _rssRepository;
        private readonly IRssSubscribRepository _rssSubscribRepository;
        private readonly UserManager<User> _userManager;    
        public RssService(IRssRepository rssRepository,IRssSubscribRepository rssSubscribRepository, UserManager<User> userManager)
        {
            _rssRepository = rssRepository;
            _rssSubscribRepository = rssSubscribRepository;
            _userManager= userManager;
        }

        public async Task<string> CreateUserRss(string userId, string url)
        {
            try
            {
                var feed = await FeedReader.ReadAsync(url);
                var rss = new RSS()
                {
                    Description = feed.Description,
                    Image = feed.ImageUrl,
                    Link = url,
                    Title = feed.Title
                };
                var rssCreated = await _rssRepository.AddRssAsync(rss);

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return "usernotfound";
                }

                var RsssubScription = new RssSubscription()
                {
                    RssId = rssCreated.Id,
                    UserId = int.Parse(userId)
                }; 
                await _rssSubscribRepository.AddAsync(RsssubScription);
                return "added";
            }
            catch (Exception ex)
            {
                return "failed";
            }
        }

        public async Task<List<RSS>> GetAllSubscribedRss(string userId)
        {
            var result = await _rssRepository.GetRssSubscribtions(userId);
            return result;
        }

        public async Task<string> RssUnUserSubscribe(string userId, int rssId)
        {
            try
            {
                userId = "11";
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return "usernotfound";
                }
                var rss = await _rssRepository.GetByIdAsync(rssId);
                if (rss == null)
                {
                    return "rssnotfound";
                }
                var rsssubScription = new RssSubscription()
                {
                    RssId = rss.Id,
                    UserId = int.Parse(userId)
                };
                await _rssSubscribRepository.DeleteAsync(rsssubScription);
                return "deleted";

            }
            catch (Exception ex)
            {
                return "failed";
            }
        }
            

        public async Task<string> RssUserSubscribe(string userId, int rssId)
        {
            try
            {
                userId = "11";
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return "usernotfound";
                }
                var rss = await _rssRepository.GetByIdAsync(rssId);
                if (rss == null)
                {
                    return "rssnotfound";
                }
                var rssSubscribtion = new RssSubscription()
                {
                    RssId = rssId,
                    UserId = user.Id
                };
                await _rssSubscribRepository.AddAsync(rssSubscribtion);
                return "added";
            }
            catch(Exception ex)
            {
                return "failed";
            }
        }
        public async Task<List<RSS>> GetAllRss(string userId)
        {
            var rssItems = await _rssRepository.GetTableNoTracking().ToListAsync();
            return rssItems;
        }

        public async Task<RSS> GetRssById(int rssId)
        {
            var rss = await _rssRepository.GetByIdAsync(rssId);
            return rss;
        }

    }
}