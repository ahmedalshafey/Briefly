using Briefly.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.SeedData
{
    public static class SeedUser
    {
        public static async Task SeedUserAsync(UserManager<User> _userManager)
        {
            var users = _userManager.Users.Count();
            if (users <= 0)
            {
                var defaultUser = new User
                {
                    FirstName = "Admin",
                    LastName = "1",
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    ProfilePicture=null,
                };
                await _userManager.CreateAsync(defaultUser,"Admin@123");
                await _userManager.AddToRoleAsync(defaultUser, "Admin");
            }
        }
    }
}