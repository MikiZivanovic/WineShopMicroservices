using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDomain.Models;
using OrderDomain.ValueObjects;

namespace OrderInfrastructure.Data.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                    orderItemId => orderItemId.Value,
                    dbId => OrderItemId.Of(dbId)

                );


            builder.HasOne<Wine>().WithMany().HasForeignKey(x => x.WineId);

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.Price).IsRequired();
        }
    }
}
