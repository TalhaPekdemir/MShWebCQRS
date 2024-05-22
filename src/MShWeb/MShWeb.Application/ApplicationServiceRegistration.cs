using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MShWeb.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration=>
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // TODO add business rules

            // TODO add repository implementation services

            return services;
        }
    }
}
