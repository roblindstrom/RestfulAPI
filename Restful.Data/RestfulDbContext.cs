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
        public DbSet<Item>? Items { get; set; }
        public DbSet<LineItem>? LineItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestfulDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}

