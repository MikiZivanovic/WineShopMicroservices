namespace OrderAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {


            return services;
        }

        public static WebApplication AddApplicationServices(this WebApplication app)
        {


            return app;
        }
    }
}
