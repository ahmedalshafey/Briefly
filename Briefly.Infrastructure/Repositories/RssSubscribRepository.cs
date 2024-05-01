using Briefly.Data.Entities;
using Briefly.Data.Identity;
using Briefly.Infrastructure.Context;
using Briefly.Infrastructure.IRepositoties;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.Repositories
{
    public class RssSubscribRepository : GenericRepository<RssSubscription>, IRssSubscribRepository
    {
        private readonly UserManager<User> _userManager;
        public RssSubscribRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }
    }
}
