using CarRentalSystemAPI.Models;
using CarRentalSystemAPI.Repositories;


namespace CarRentalSystemAPI.Services
{
    public class CarRentalService : ICarRentalService
    {
        private readonly ICarRepository carRepository;
        private readonly IUserRepository userRepository;
        private readonly RentalRepository rentalRepository;
        private readonly NotificationService notificationService;

        public CarRentalService(ICarRepository carRepository, IUserRepository userRepository,
            RentalRepository rentalRepository, NotificationService notificationService)
        {
            this.carRepository = carRepository;
            this.userRepository = userRepository;
            this.rentalRepository = rentalRepository;
            this.notificationService = notificationService;
        }
        public async Task<decimal> RentCar(int carId,int userId, int rentalDays)
        {
            var user = await userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var car = await carRepository.GetCarById(carId);

            if (car == null || !car.IsAvailable)
                throw new Exception("Car is not available");

            decimal totalPrice = rentalDays * car.PricePerDay;
            car.IsAvailable = false;
            await carRepository.UpdateCarAvailability(carId, car);

            var rental = new Rental
            {
                UserId = userId,
                CarId = carId,
                RentalDate = DateTime.Now.Date,
                RentalDays = rentalDays,
                TotalPrice = totalPrice,

            };

            await rentalRepository.AddRental(rental);

            await notificationService.SendRentalConfirmation(user.Email, car, rentalDays, totalPrice);

            return totalPrice;
        }
        public async Task<bool> CheckCarAvailability(int carId)
        {
            var car = await carRepository.GetCarById(carId);

            return car != null && car.IsAvailable;
        }
    }
}

