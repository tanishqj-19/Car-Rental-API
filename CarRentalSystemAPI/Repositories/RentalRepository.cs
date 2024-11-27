using CarRentalSystemAPI.Data;
using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repositories
{
    public class RentalRepository
    {
        private readonly CarDbContext _context;

        public RentalRepository(CarDbContext context)
        {
            this._context = context;
        }

        public async Task AddRental(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }
    }
}
