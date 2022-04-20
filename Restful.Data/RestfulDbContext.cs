using Microsoft.EntityFrameworkCore;
using Restful.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Data
{
    public class RestfulDbContext : DbContext
    {

        public RestfulDbContext(DbContextOptions<RestfulDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Order>? Orders { get; set; }
        public DbSet<Package>? Packages { get; set; }
        public DbSet<Content>? Contents { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestfulDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}

