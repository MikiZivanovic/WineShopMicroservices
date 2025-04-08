using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDomain.Abstractions;
using OrderDomain.ValueObjects;

namespace OrderDomain.Models
{
    public class OrderItem : Entity<OrderItemId>
    {
        internal OrderItem(OrderId orderId, WineId wineId, int quantity, decimal price)
        {
            Id = OrderItemId.Of(Guid.NewGuid());
            OrderId = orderId;
            WineId = wineId;
            Quantity = quantity;    
            Price = price;
        }
        public OrderId OrderId { get; private set; } = default!;

        public WineId WineId { get; private set; } = default!;

        public int Quantity { get; private set; } = default!;

        public decimal Price { get; private set; } = default!;
    }
}
