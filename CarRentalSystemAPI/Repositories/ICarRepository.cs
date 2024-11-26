using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repositories
{
    public interface ICarRepository
    {
        Task<Car?> GetCarById(int id);
        Task<IEnumerable<Car>> GetAvailableCars();
        Task AddCar(Car car);
        Task UpdateCarAvailability(int Id, bool newAvailability);
        
        Task DeleteCarById(int Id);
    }
}
