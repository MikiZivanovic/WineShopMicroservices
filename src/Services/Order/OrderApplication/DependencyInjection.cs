using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Behaviors;
using BuildingBlocksMessaging.MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace OrderApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration) {

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddFeatureManagement();
            services.AddMessageBroker(configuration,Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
