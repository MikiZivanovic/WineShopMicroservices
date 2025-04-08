using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using OrderApplication.Data;
using OrderApplication.Extensions;

namespace OrderApplication.Orders.Queries.GetOrdersByName
{
    public class GetOrdersByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders.Include(o=>o.OrderItems).AsNoTracking().Where(o=>o.OrderName.Value.Contains(query.Name)).OrderBy(o=>o.OrderName.Value).ToListAsync(cancellationToken);

            var ordersDtos = orders.ToOrderDtoList();

            return new GetOrdersByNameResult(ordersDtos);
        }
    }
}
