using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MShWeb.Application.Services.Repositories;
using MShWeb.Application.Services.UnitOfWork;
using MShWeb.Persistence.Contexts;
using MShWeb.Persistence.Repositories;

namespace MShWeb.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MShCQRSDb")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
