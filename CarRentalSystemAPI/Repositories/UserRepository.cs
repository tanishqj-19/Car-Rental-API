

using CarRentalSystemAPI.Models;

namespace CarRentalSystemAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> allUsers = new List<User>();  
        public Task AddUser(User user)
        {
            allUsers.Add(user);

            return Task.CompletedTask;
        }

        public Task<User> GetUserByEmail(string email)
        {
            var currUser = allUsers.Find(x=> x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (currUser == null)
            {
                return Task.FromResult<User>(new User());
            }

            return Task.FromResult<User>(currUser);
        }

        public Task<User> GetUserById(int Id)
        {
            var currUser = allUsers.Find(user => user.Id == Id);
            if (currUser == null)
            {
                return Task.FromResult<User>(new User());
            }

            return Task.FromResult<User>(currUser);

        }
    }
}
