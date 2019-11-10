using System.Threading.Tasks;

using Auth.Core.Models;

namespace Auth.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUser> AuthenticateAsync(Credentials credentials);
        Task<AuthenticatedUser> RefreshAsync(Token token);
    }
}