using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using BuildingBlocks.Paginations;
using OrderApplication.Dtos;

namespace OrderApplication.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(PaginatedRequest PaginatedRequest) : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
 
}
