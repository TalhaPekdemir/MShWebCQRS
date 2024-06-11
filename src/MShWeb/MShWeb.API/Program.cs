using MShWeb.Persistence;
using MShWeb.Application;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

namespace MShWeb.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                //.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                ;

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



            // if wwwroot or upload path does not exist will throw error
            var providerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", @builder.Configuration?.GetSection("UploadSettings")["Path"]);
            if (!Directory.Exists(providerPath))
            {
                Directory.CreateDirectory(providerPath);
            }

            app.UseStaticFiles(new StaticFileOptions() 
                {
                    FileProvider = new PhysicalFileProvider(providerPath),
                    RequestPath = new PathString($"/{builder.Configuration?.GetSection("UploadSettings")["Path"]}")
                });;
            

            app.MapControllers();

            app.Run();

            
        }
    }
}
