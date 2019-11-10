using System.Threading.Tasks;
using Auth.Core.Models;

namespace Auth.Core.Interfaces
{
    public interface ITokenService
    {
        Task<bool> ValidateAccessTokenAsync(string accessToken);
        Task<bool> ValidateRefreshTokenAsync(string refreshToken, UserDetails userDetails);
        Task<Token> GenerateTokenAsync(UserDetails userDetails);
        Task<UserDetails> DecodeAccessTokenAsync(string accessToken);
    }
}