using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using MediatR;
using OrderApplication.Data;
using OrderApplication.Dtos;
using OrderDomain.Models;
using OrderDomain.ValueObjects;

namespace OrderApplication.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult>  Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {

            var order = CreateNewOrder(command.Order);
            
            dbContext.Orders.Add(order);

            
             var result = await dbContext.SaveChangesAsync(cancellationToken);
            
           
          

            return new CreateOrderResult(order.Id.Value);

        }

        private Order CreateNewOrder(OrderDto order)
        {
            var paymert = Payment.Of(order.Payment.CardName,order.Payment.CardNumber,order.Payment.Exparation,order.Payment.Cvv);

            var neworder = Order.Create(OrderId.Of(Guid.NewGuid()),CustomerId.Of(order.CustomerId),OrderName.Of(order.OrderName),paymert);

            foreach (var item in order.OrderItems) {

                neworder.Add(WineId.Of(item.ProductId),item.Quantity,item.Price);
            }

            return neworder;
        }
    }
}
