using Microsoft.Extensions.DependencyInjection;
using MShWeb.Application.Features.Products.Rules;
using MShWeb.Application.Services.Files;
using MShWeb.Application.Services.Images;
using MShWeb.Application.Services.Products;
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
            services.AddScoped<ProductBusinessRules>();

            // TODO add repository implementation services
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IImageService, ImageManager>();
            services.AddScoped<IFileService, StaticFileService>();

            return services;
        }
    }
}
