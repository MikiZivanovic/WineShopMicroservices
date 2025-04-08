using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using OrderApplication.Dtos;

namespace OrderApplication.Orders.Queries.GetOrdesByCustomer
{
    public record GetOrdesByCustomerQuery(Guid CustomerId) : IQuery<GetOrdesByCustomerResult>;

    public record GetOrdesByCustomerResult(IEnumerable<OrderDto> Orders);

}
