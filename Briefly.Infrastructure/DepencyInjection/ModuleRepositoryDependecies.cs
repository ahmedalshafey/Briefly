using Briefly.Infrastructure.IRepositoties;
using Briefly.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.DepencyInjection
{
    public static class ConfigurationRepository
    {
        public static IServiceCollection AddRepositoryDependinces(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
            services.AddTransient<IRssRepository, RssRepository>();
            services.AddTransient<IRssSubscribRepository, RssSubscribRepository>();
            return services;
        }
    }
}
