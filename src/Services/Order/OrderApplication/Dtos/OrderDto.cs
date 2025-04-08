using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDomain.Models;

namespace OrderApplication.Dtos
{
    public record OrderDto(Guid Id, Guid CustomerId, string OrderName, OrderStatus Status,PaymentDto Payment ,List<OrderItemDto> OrderItems);
}
