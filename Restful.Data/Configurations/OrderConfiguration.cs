using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restful.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(x => x.OrderId);

            builder
                .HasMany(o => o.Packages)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
        }
    }
}
