using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using OrderApplication.Data;
using OrderApplication.Extensions;

namespace OrderApplication.Orders.Queries.GetOrders
{
    public class GetOrdersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginatedRequest.PageIndex;

            var pageSize = query.PaginatedRequest.PageSize;

            var count = await dbContext.Orders.LongCountAsync(cancellationToken);

            var orders = await dbContext.Orders.Include(o=>o.OrderItems).OrderBy(o=>o.OrderName.Value).Skip(pageIndex*pageSize).Take(pageSize).AsNoTracking().ToListAsync();

            return new GetOrdersResult(new BuildingBlocks.Paginations.PaginatedResult<Dtos.OrderDto>(pageIndex, pageSize, count, orders.ToOrderDtoList()));
        }
    }
}
