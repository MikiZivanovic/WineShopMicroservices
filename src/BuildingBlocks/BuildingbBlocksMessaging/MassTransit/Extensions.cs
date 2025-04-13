using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocksMessaging.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration, Assembly? assembly=null) {


            services.AddMassTransit(conf => {

                conf.SetKebabCaseEndpointNameFormatter();

                if (assembly != null) {

                    conf.AddConsumers(assembly);
                }

                conf.UsingRabbitMq((context ,cfg) => {

                    cfg.Host(new Uri(configuration["MessageBroker:Host"]!), host => {

                        host.Username(configuration["MessageBroker:UserName"]);

                        host.Password(configuration["MessageBroker:Password"]);

                    });
                    cfg.ConfigureEndpoints(context);
                
                
                });
            
            
            });


            return services;
        }
    }
}
