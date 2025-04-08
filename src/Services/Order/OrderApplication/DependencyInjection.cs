using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace OrderApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            
            return services;
        }
    }
}
