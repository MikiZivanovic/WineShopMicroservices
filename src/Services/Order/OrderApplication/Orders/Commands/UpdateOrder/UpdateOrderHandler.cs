using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using OrderApplication.Data;
using OrderApplication.Dtos;
using OrderApplication.Exceptions;
using OrderApplication.Orders.Commands.CreateOrder;
using OrderDomain.Models;
using OrderDomain.ValueObjects;

namespace OrderApplication.Orders.Commands.UpdateOrder
{
    public class UpdateOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.Order.Id);

            var order = await dbContext.Orders.FindAsync([orderId],cancellationToken);

            if (order == null) {

                throw new OrderNotFoundException(command.Order.Id);
            }

            UpdateOrderWithNewValues(order,command.Order);

            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateOrderResult(true);
        }

        private void UpdateOrderWithNewValues(Order order,OrderDto orderDto)
        {
            var payment = Payment.Of(orderDto.Payment.CardName,orderDto.Payment.CardNumber,orderDto.Payment.Exparation,orderDto.Payment.Cvv);

            order.Update(OrderName.Of(orderDto.OrderName),payment,orderDto.Status);
        }
    }
}
