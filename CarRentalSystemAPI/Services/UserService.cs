using CarRentalSystemAPI.Models;
using CarRentalSystemAPI.Repositories;

namespace CarRentalSystemAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AuthService _authService;
        private readonly IUserRepository userRepository;

        public UserService(AuthService authService, IUserRepository userRepository)
        {
            this._authService = authService;
            this.userRepository = userRepository;
        }

        public async Task<string> RegisterUser(User newUser)
        {
            var existingUser = await userRepository.GetUserById(newUser.Id);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
            // Hashed the user PASSWORD
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await userRepository.AddUser(newUser);

            return _authService.GenerateToken(newUser);

        }

        public async Task<string> AuthenticateUser(string email, string password)
        {
            var existingUser = await userRepository.GetUserByEmail(email);

            if (existingUser == null )
            {
                throw new Exception("User does not exist!");
            }
            if(!BCrypt.Net.BCrypt.Verify(password, existingUser.Password)){
                throw new Exception("Either email or password is not correct");
            }
            

            return _authService.GenerateToken(existingUser).ToString();
        }
    }
}
