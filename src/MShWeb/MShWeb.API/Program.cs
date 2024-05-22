using MShWeb.Persistence;
using MShWeb.Application;
using Microsoft.Extensions.FileProviders;

namespace MShWeb.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseStaticFiles(new StaticFileOptions() 
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", @builder.Configuration?.GetSection("UploadSettings")["Path"]!)),
                    RequestPath = new PathString($"/{builder.Configuration?.GetSection("UploadSettings")["Path"]}")
                });;
            

            app.MapControllers();

            app.Run();

            
        }
    }
}
