using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using OrderApplication.Dtos;

namespace OrderApplication.Orders.Queries.GetOrdersByName
{

    public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);

    
}
