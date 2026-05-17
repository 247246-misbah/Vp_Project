using Microsoft.EntityFrameworkCore;
using Misbah_VisualProgramming_Project.Data;

namespace Misbah_VisualProgramming_Project.Services
{
    public class AuthService
    {
        private readonly CafeDbContext _context;

        public AuthService(CafeDbContext context)
        {
            _context = context;
        }

        public async Task<User?> ValidateUserAsync(string usernameOrEmail, string password)
        {
            // Database mein username ya email match karke user dhoondte hain
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);

            if (user != null)
            {
                // Note: Production mein password hashing use hoti hai (BCrypt/Identity), 
                // Student project presentation ke liye hum direct ya clean structural hash verification match kar rahe hain.
                if (user.PasswordHash == password)
                {
                    return user; // Success
                }
            }
            return null; // Invalid credentials
        }
    }
}