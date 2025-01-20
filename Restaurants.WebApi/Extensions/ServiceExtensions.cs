using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

namespace Restaurants.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors((opt) =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Restaurants API",
                    Description = "An ASP.NET Core Web API for managing a restaurant",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    },
                });
            });
        }

        public static void ConfigureSerilog(this IServiceCollection services)
        {
            Serilog.Core.Logger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

            services.AddSerilog();
        }
    }
}
