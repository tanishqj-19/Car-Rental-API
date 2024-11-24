using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private static List<Car> cars = new List<Car>();

        public Task<Car> GetCarById(int Id)
        {
            var carById = cars.Find(x => x.Id == Id);
            if(carById == null)
            {
                return Task.FromResult<Car>(new Car());
            }
            return Task.FromResult<Car>(carById);
        }

        public Task<IEnumerable<Car>> GetAvailableCars()
        {
            var carsAvailable = cars.Where(currCar => currCar.IsAvailable).ToList();

            return Task.FromResult(carsAvailable.AsEnumerable());
        }

        public Task AddCar(Car newCar)
        {
            cars.Add(newCar);

            return Task.CompletedTask;

        }
        public Task UpdateCarAvailability(int Id, bool newAvailability)
        {
            var carToBeUpdated = cars.Find(c => c.Id == Id);

            if (carToBeUpdated != null)
            {
                carToBeUpdated.IsAvailable = newAvailability;
            }

            return Task.CompletedTask;
        }
    }
}
