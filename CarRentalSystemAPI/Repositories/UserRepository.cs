

using CarRentalSystemAPI.Data;
using CarRentalSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystemAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CarDbContext context;

        public UserRepository(CarDbContext context)
        {
            this.context = context;
        }
        public async Task AddUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();


        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var currUser = await context.Users.FirstOrDefaultAsync(u=> u.Email.Equals(email));

            return currUser;
        }

        public async Task<User?> GetUserById(int Id)
        {
            var currUser = await context.Users.FindAsync(Id);
           
            return currUser;

        }

        
    }
}
