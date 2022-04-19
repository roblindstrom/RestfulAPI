using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restful.Data;
using Restful.Data.Repositories;
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

            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDataServices(configuration);

            return services;
        }

    }
}
