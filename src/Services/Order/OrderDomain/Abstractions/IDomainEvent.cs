﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OrderDomain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        Guid EventId  =>  Guid.NewGuid();

        public DateTime OccuredOn => DateTime.UtcNow;

        public string EventType => GetType().AssemblyQualifiedName;
    }
}
