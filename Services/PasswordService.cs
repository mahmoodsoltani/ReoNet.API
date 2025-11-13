using System.Security.Cryptography;
using System.Text;

namespace ReoNet.Api.Services
{
    public class PasswordService
    {
        // تولید Salt به صورت byte[]
        public static byte[] GenerateSalt(int size = 16)
        {
            var salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // هش پسورد با Salt
        public static string HashPassword(string password, byte[] salt)
        {
            var combined = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(combined);
                return Convert.ToBase64String(hash);
            }
        }

        // بررسی پسورد
        public static bool VerifyPassword(string password, byte[] salt, string storedHash)
        {
            var hash = HashPassword(password, salt);
            return hash == storedHash;
        }
    }
}
