using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restful.Data;
using Restful.Data.Repositories;
using Restful.Services.Services.Seeds;
using Restful.Shared.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Services
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();

            services.AddScoped<ISeedService, SeedService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDataServices(configuration);

            return services;
        }

    }
}
