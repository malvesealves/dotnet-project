using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInterfaces(this IServiceCollection services, IConfiguration configuration)
        {
            string? connString = configuration.GetConnectionString("RestaurantsDb");
            services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connString));
        }
    }
}
