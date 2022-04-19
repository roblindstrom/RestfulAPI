using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Data
{
    public static class DataServiceRegistration
    {

        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RestfulDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RestfulDb"),
                b => b.MigrationsAssembly(typeof(RestfulDbContext).Assembly.FullName)));

            return services;
        }



    }
}
