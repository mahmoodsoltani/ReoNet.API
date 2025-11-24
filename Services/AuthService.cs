using Microsoft.EntityFrameworkCore;
using ReoNet.Api.Data;
using ReoNet.Api.Models.Auth;

namespace ReoNet.Api.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SecUser?> RegisterAsync(
            string username,
            string password,
            string email,
            string? firstName = null,
            string? lastName = null
        )
        {
            if (await _context.SecUsers.AnyAsync(u => u.Username == username))
                throw new Exception("Username already exists.");

            var salt = PasswordService.GenerateSalt();
            var hash = PasswordService.HashPassword(password, salt);

            var user = new SecUser
            {
                Username = username,
                Password = hash,
                Salt = salt,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Enabled = true,
                IsActive = true,
                RegisterDate = DateTime.UtcNow.ToString("yyyy-MM-dd")
            };

            _context.SecUsers.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<SecUser?> LoginAsync(string email, string password)
        {
            var user = await _context.SecUsers.FirstOrDefaultAsync(u => u.Email == email || u.Username == email);

            if (user == null || user.Salt == null || user.Password == null)
                return null;

            var valid = PasswordService.VerifyPassword(password, user.Salt, user.Password);
            return valid ? user : null;
        }
    }
}
