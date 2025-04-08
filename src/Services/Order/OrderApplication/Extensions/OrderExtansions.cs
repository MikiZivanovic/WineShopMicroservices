using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderApplication.Dtos;
using OrderDomain.Models;

namespace OrderApplication.Extensions
{
    public static class OrderExtansions
    {
        public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
        {
            return orders.Select(order =>order.ToOrderDto());
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return DtoFromOrder(order);
        }

        private static OrderDto DtoFromOrder(Order order)
        {
            return new OrderDto(
                        Id: order.Id.Value,
                        CustomerId: order.CustomerId.Value,
                        OrderName: order.OrderName.Value,
                        Payment: new PaymentDto(order.Payment.CardName!, order.Payment.CardNumber, order.Payment.Exparation, order.Payment.CVV),
                        Status: order.Status,
                        OrderItems: order.OrderItems.Select(oi => new OrderItemDto(oi.OrderId.Value, oi.WineId.Value, oi.Quantity, oi.Price)).ToList()
                    );
        }
    }
}
