using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OrderDomain.Abstractions;

namespace OrderInfrastructure.Data.Interceptors
{
    public class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {

            DispatchDomainEvent(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {

            await DispatchDomainEvent(eventData.Context);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }


        private async Task DispatchDomainEvent(DbContext? context) {

            if (context == null) {
                return;
            }

            var aggregate = context.ChangeTracker.Entries<IAggregate>().Where(x=>x.Entity.DomainEvents.Any()).Select(x => x.Entity);

            var events = aggregate.SelectMany(x => x.DomainEvents).ToList();

            aggregate.ToList().ForEach(x => x.ClearDomainEvents());


            foreach (var e in events) {
            
               await mediator.Publish(e);
            }

        }
    }
}
