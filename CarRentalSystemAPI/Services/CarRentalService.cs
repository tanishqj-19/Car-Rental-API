using CarRentalSystemAPI.Repositories;
using OneOf;

namespace CarRentalSystemAPI.Services
{
    public class CarRentalService : ICarRentalService
    {
        private readonly ICarRepository carRepository;

        public CarRentalService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public async Task<decimal> RentCar(int carId, int userId, int rentalDays)
        {
            var car = await carRepository.GetCarById(carId);

            if (car == null || !car.IsAvailable) return -1;
            

            car.IsAvailable = false;
            await carRepository.UpdateCarAvailability(carId, false);

            
            decimal totalPrice = rentalDays * car.PricePerDay;

            return totalPrice;
        }
        public async Task<bool> CheckCarAvailability(int carId)
        {
            var car = await carRepository.GetCarById(carId);

            return car != null && car.IsAvailable;
        }
    }
}

