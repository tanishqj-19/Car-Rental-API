using OneOf;

namespace CarRentalSystemAPI.Services
{
    public interface ICarRentalService
    {
        Task<decimal> RentCar(int carId, int userId, int rentalDays);
        Task<bool> CheckCarAvailability(int carId);
    }
}
