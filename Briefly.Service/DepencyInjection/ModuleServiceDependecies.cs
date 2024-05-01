using Briefly.Service.Implemintations.Auth;
using Briefly.Service.Implemintations.Rss;
using Briefly.Service.Interfaces.Auth;
using Briefly.Service.Interfaces.Rss;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.DepencyInjection
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddServiceDependinces(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IRssService, RssService>();
            return services;
        }
    }
}
