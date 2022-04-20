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
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder
                .HasKey(p => p.PackageId);

            builder
                .HasOne(p => p.Order)
                .WithMany(o => o.Packages)
                .HasForeignKey(p => p.OrderId);

            builder
                .HasMany(p => p.Contents)
                .WithOne(c => c.Package)
                .HasForeignKey(c => c.PackageId);
        }
    }
}
