using System.Linq;
using System.Threading.Tasks;
using Auth.Core.Interfaces;
using Auth.Core.Models;

namespace Auth.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {   
        private readonly ITokenService _tokenService;
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _hasher;

        public AuthenticationService(
            IPasswordHasher hasher, ITokenService tokenService, IUsersRepository usersRepository)
        {
            this._hasher = hasher;
            this._tokenService = tokenService;
            this._usersRepository = usersRepository;
        }

        public async Task<AuthenticatedUser> AuthenticateAsync(Credentials credentials)
        {
            var user = this._usersRepository
                .FindByCondition(u => u.Username == credentials.Username)
                .SingleOrDefault();

            if (user == null)
            {
                return null;
            }
            
            var valid = await this._hasher.ValidateHashAsync(credentials.Password, user.Password);

            if (valid == null)
            {
                return null;
            }

            var userDetails = new UserDetails 
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role
            };

            var token = await this._tokenService.GenerateTokenAsync(userDetails);
           
            return new AuthenticatedUser
            {
                User = userDetails,
                Token = token
            };
        }

        public async Task<AuthenticatedUser> RefreshAsync(Token token)
        {
            var isAccessTokenValid = await this._tokenService.ValidateAccessTokenAsync(token.AccessToken);

            if (!isAccessTokenValid)
            {
                return null;
            }

            var userDetails = await this._tokenService.DecodeAccessTokenAsync(token.AccessToken);

            if (userDetails == null)
            {
                return null;
            }

            var isRefreshTokenValid = await this._tokenService.ValidateRefreshTokenAsync(token.RefreshToken, userDetails);

            if (!isRefreshTokenValid)
            {
                return null;
            }

            var refreshedToken = await this._tokenService.GenerateTokenAsync(userDetails);

            return new AuthenticatedUser
            {
                User = userDetails,
                Token = refreshedToken
            };
        }

    }
}