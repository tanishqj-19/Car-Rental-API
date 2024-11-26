using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Services
{
    public interface IUserService
    {
        public Task<string> RegisterUser(User user);

        public Task<string> AuthenticateUser(string email, string password);
    }
}
