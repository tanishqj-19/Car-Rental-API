using CarRentalSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystemAPI.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

    }
}
