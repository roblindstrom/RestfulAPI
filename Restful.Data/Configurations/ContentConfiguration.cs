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
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder
                .HasKey(c => c.ContentId);

            builder
                .HasOne(c => c.Package)
                .WithMany(p => p.Contents)
                .HasForeignKey(c => c.PackageId);
        }
    }
}
