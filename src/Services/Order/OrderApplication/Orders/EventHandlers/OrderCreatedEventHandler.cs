using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.FeatureManagement;
using OrderApplication.Extensions;
using OrderDomain.Events;

namespace OrderApplication.Orders.EventHandlers
{
    public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint,IFeatureManager featureManager) : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {

            if (await featureManager.IsEnabledAsync("OrderFullfilment")) { 
                
                var orderDto = domainEvent.order.ToOrderDto();
                await publishEndpoint.Publish(orderDto,cancellationToken);
            
            }
          
        }
    }
}
