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
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                    orderId => orderId.Value,
                    dbid => OrderId.Of(dbid)
                );

            builder.HasOne<Customer>().WithMany().HasForeignKey(x => x.CustomerId).IsRequired();

            builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey(x => x.OrderId);


            builder.ComplexProperty(
                o=>o.OrderName,nameBuilder=>
                    {
                        nameBuilder.Property(n => n.Value).HasColumnName(nameof(Order.OrderName)).HasMaxLength(100).IsRequired();
                    }
                );
            builder.ComplexProperty(
                    p => p.Payment, paymentBuilder => {

                        paymentBuilder.Property(x => x.CardName).HasMaxLength(50);


                        paymentBuilder.Property(x => x.CardNumber).HasMaxLength(24).IsRequired();

                        paymentBuilder.Property(x => x.Exparation).HasMaxLength(10);

                        paymentBuilder.Property(p => p.CVV).HasMaxLength(3);

                    }
                );

            builder.Property(x => x.Status).HasDefaultValue(OrderStatus.Draft).HasConversion(
                    status=>status.ToString(),
                    db => (OrderStatus)Enum.Parse(typeof(OrderStatus),db)
                );
            builder.Property(x => x.TotalPrice);
        }
    }
}
