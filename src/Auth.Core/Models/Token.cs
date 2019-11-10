using System;

namespace Auth.Core.Models
{
    public class Token {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}