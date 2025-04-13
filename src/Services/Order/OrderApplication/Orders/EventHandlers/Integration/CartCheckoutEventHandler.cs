using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocksMessaging.Events;
using MassTransit;
using MediatR;
using OrderApplication.Dtos;
using OrderApplication.Orders.Commands.CreateOrder;
using OrderDomain.Models;
using OrderDomain.ValueObjects;

namespace OrderApplication.Orders.EventHandlers.Integration
{
    public class CartCheckoutEventHandler(ISender sender) : IConsumer<CartCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<CartCheckoutEvent> context)
        {
            var command = ConvertEventToCommand(context.Message);

            await sender.Send(command);
        }


        public CreateOrderCommand ConvertEventToCommand(CartCheckoutEvent cartEvent) {

            var paymentDto = new PaymentDto(cartEvent.CardName,cartEvent.CardNumber,cartEvent.Exparation,cartEvent.CVV);

            var orderId = Guid.NewGuid();

            var orderDto = new OrderDto(orderId, cartEvent.CustomerId,cartEvent.UserName,OrderStatus.Pending,paymentDto,cartEvent.Items.Select((item)=>new OrderItemDto(orderId,item.WineId,item.Quantity,item.Price)).ToList());
            
            return new CreateOrderCommand(orderDto);
        
        }
    }
}
