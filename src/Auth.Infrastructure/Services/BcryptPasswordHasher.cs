using System;
using System.Threading.Tasks;
using BCrypt.Net;
using Auth.Core.Interfaces;

namespace Auth.Infrastructure.Services
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public async Task<string> HashAsync(string value)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(value, GetRandomSalt());
            return BCrypt.Net.BCrypt.HashPassword(value, GetRandomSalt());
        }

        public async Task<bool> ValidateHashAsync(string raw, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(raw, hash);
        }

        private string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
    }
}