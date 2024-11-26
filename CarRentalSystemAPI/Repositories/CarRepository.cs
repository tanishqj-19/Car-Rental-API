using CarRentalSystemAPI.Data;
using CarRentalSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystemAPI.Repositories
{   
    public class CarRepository : ICarRepository
    {
        private CarDbContext context;
        public CarRepository(CarDbContext context)
        {
            this.context = context;
        }
        private static List<Car> cars = new List<Car>();

        public async Task<Car?> GetCarById(int Id)
        {
            var carById = await context.Cars.FindAsync(Id);
            if(carById == null)
            {
                return null;
            }
            return carById;
        }

        public async Task<IEnumerable<Car>> GetAvailableCars()
        {
            var carsAvailable = await context.Cars.Where(currCar => currCar.IsAvailable).ToListAsync();

            return carsAvailable;
        }

        public async Task AddCar(Car newCar)
        {
            await context.Cars.AddAsync(newCar);
            await context.SaveChangesAsync();

            

        }
        public async Task UpdateCarAvailability(int Id, bool newAvailability)
        {
            var carToBeUpdated = await context.Cars.FindAsync(Id);

            if (carToBeUpdated != null)
            {
                carToBeUpdated.IsAvailable = newAvailability;
                context.Cars.Update(carToBeUpdated);
                await context.SaveChangesAsync();
            }

            
        }

        public async Task DeleteCarById(int Id)
        {
            var currCar = await context.Cars.FindAsync(Id);
            

            if (currCar != null)
            {
                context.Cars.Remove(currCar);
                await context.SaveChangesAsync();
            }

            
        }
    }
}
