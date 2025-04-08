using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDomain.Abstractions;
using OrderDomain.ValueObjects;

namespace OrderDomain.Models
{
    public class Wine : Entity<WineId>
    {
        public string Name { get; private set; } = default!;

        public decimal Price { get; private set; } = default!;

        public static Wine Create(WineId id, string name, decimal price)
        {

            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            var wine = new Wine()
            {
                Id = id,
                Name = name,
                Price = price
            };

            return wine;
        }
    }
}
