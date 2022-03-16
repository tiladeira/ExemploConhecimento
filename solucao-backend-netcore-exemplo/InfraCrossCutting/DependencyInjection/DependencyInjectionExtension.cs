using Domain.Interfaces.Services;
using Domain.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCrossCutting.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options =>
                options
                    //.UseSQL(configuration.GetConnectionString("Default"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            TransientServices(services);
            Repositories(services);

            return services;
        }

        private static IServiceCollection TransientServices(IServiceCollection services)
        {
            services.AddTransient<ICidadaoService, CidadaoService>();

            return services;
        }

        private static IServiceCollection Repositories(IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
