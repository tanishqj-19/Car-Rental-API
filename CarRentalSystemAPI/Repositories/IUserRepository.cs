using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        Task<User?> GetUserByEmail(string email);

        Task<User?> GetUserById(int Id);
    }
}
