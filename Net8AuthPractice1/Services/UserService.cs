using Microsoft.EntityFrameworkCore;
using Net8AuthPractice1.Data;
using Net8AuthPractice1.Models;
using System.Diagnostics.Eventing.Reader;

namespace Net8AuthPractice1.Services
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<(bool success, string message)> AuthenticateUser(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
                return (false, "User not found");

            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return (true, "Authentication successful");

            return (false, "Invalid password");
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        // If you need a method to create a new user or update a password:
        public async Task<bool> CreateUser(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
