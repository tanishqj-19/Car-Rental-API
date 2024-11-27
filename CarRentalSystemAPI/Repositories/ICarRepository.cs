using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repositories
{
    public interface ICarRepository
    {
        Task<Car?> GetCarById(int id);
        Task<IEnumerable<Car>> GetAvailableCars();
        Task AddCar(Car car);
        Task UpdateCarAvailability(int Id, Car car);
        
        Task DeleteCarById(int Id);
    }
}
