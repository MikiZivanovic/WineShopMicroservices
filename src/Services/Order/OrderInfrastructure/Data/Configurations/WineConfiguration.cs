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
    public class WineConfiguration : IEntityTypeConfiguration<Wine>
    {
        public void Configure(EntityTypeBuilder<Wine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                 wineId => wineId.Value,
                 dbId => WineId.Of(dbId)
                );

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

  

        }
    }
}
