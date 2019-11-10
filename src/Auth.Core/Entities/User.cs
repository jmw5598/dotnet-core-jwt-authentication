using System;
using Auth.Core.Models;
using Auth.Core.Shared;

namespace Auth.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}