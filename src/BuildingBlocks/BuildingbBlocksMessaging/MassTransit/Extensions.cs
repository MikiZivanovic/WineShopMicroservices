using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocksMessaging.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection services, Assembly? assembly=null) {

            return services;
        }
    }
}
