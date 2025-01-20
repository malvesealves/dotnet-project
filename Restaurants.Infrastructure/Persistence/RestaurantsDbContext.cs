using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    internal class RestaurantsDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        internal DbSet<Address> Addresses { get; set; }
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<Dish> Dishes { get; set; }
        internal DbSet<Restaurant> Restaurants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>().HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantId);
            modelBuilder.Entity<Restaurant>().HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantId);
        }
    }
}
