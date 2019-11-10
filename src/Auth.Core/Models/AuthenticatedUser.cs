namespace Auth.Core.Models
{
    public class AuthenticatedUser
    {
        public UserDetails User { get; set; }
        public Token Token { get; set; }
    }
}