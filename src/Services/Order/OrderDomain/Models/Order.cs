using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDomain.Abstractions;
using OrderDomain.Events;
using OrderDomain.ValueObjects;

namespace OrderDomain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();

        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();


        public CustomerId CustomerId { get; private set; } = default!;

        public OrderName OrderName { get; set; } = default!;

        public Payment Payment { get; private set; } = default!;

        public OrderStatus Status { get; private set; } = OrderStatus.Pending;

        public decimal TotalPrice {
            get => OrderItems.Sum(x => x.Price * x.Quantity);

            private set { }
        
        }

       


        public static Order Create(OrderId id, CustomerId customerId, OrderName orderName, Payment payment) {

            var order = new Order
            {
                Id = id,
                CustomerId = customerId,
                OrderName = orderName,
                Payment = payment,
                

            };
            order.AddDomainEvent(new OrderCreatedEvent(order));

            return order;
        }

        public void Update(OrderName orderName, Payment payment, OrderStatus status) { 
        
            OrderName = orderName;
            Payment = payment;
            Status = status;

            AddDomainEvent(new OrderUpdateEvent(this));
        
        }


        public void Add(WineId wineId, int quantity, decimal price ) {

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            var orderItem = new OrderItem(Id,wineId, quantity, price);


            _orderItems.Add(orderItem); 
        }

        public void Remove(WineId WineId) {

            var item = _orderItems.FirstOrDefault(x => x.WineId == WineId);
            if (item is not null) { 
            
                _orderItems.Remove(item);
            }
        
        }


    }
}
