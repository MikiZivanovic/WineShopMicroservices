using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDomain.Abstractions;
using OrderDomain.Models;

namespace OrderDomain.Events
{
    public record OrderCreatedEvent(Order order) : IDomainEvent;
    
}
