using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using OrderApplication.Data;
using OrderApplication.Extensions;
using OrderDomain.ValueObjects;

namespace OrderApplication.Orders.Queries.GetOrdesByCustomer
{
    public class GetOrdesByCustomerHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdesByCustomerQuery, GetOrdesByCustomerResult>
    {
        public async  Task<GetOrdesByCustomerResult> Handle(GetOrdesByCustomerQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders.Include(o => o.OrderItems).AsNoTracking().Where(o => o.CustomerId== CustomerId.Of(query.CustomerId)).OrderBy(o => o.OrderName.Value).ToListAsync(cancellationToken);

            return new GetOrdesByCustomerResult( orders.ToOrderDtoList());
        }
    }
}
