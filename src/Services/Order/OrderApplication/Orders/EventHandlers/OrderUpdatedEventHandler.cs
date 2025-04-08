using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderDomain.Events;

namespace OrderApplication.Orders.EventHandlers
{
    public class OrderUpdatedEventHandler : INotificationHandler<OrderUpdateEvent>
    {
        public Task Handle(OrderUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
