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
    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder
                .HasKey(li => li.LineItemId);

            builder
                .HasOne(li => li.Item)
                .WithMany(i => i.LineItems)
                .HasForeignKey(li => li.ItemId);
        }
    }
}
