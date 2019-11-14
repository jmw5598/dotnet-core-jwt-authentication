using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Auth.Core.Entities;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Infrastructure.Data;
using Auth.Web.Models;

namespace Auth.Web.Controller
{
    [ApiController]
    [Route("auth/")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _hasher;
        private readonly IUsersRepository _usersRepository;

        public AuthenticationController(IAuthenticationService authenticationService, 
            ITokenService tokenService, IPasswordHasher hasher, IUsersRepository usersRepository)
        {
            this._authenticationService = authenticationService;
            this._hasher = hasher;
            this._tokenService = tokenService;
            this._usersRepository = usersRepository;
        }

        [AllowAnonymous]
        [HttpPost("tokens")]
        public async Task<ActionResult<AuthenticatedUser>> AuthenticateUser([FromBody] AuthenticateUserBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var credentials = new Credentials
            {
                Username = model.Username,
                Password = model.Password
            };

            var authenticatedUser = await this._authenticationService.AuthenticateAsync(credentials);

            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            return Ok(authenticatedUser);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<object>> RegisterUser(UserBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var user = new User
            {
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = await this._hasher.HashAsync(model.Password),
                Role = Role.USER
            };

            this._usersRepository.Create(user);

            return Ok("Created");
        }            

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ActionResult<object>> RefreshToken([FromBody] RefreshAuthenticatedUserBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = new Token 
            {
                AccessToken = model.AccessToken,
                RefreshToken = model.RefreshToken
            };

            var authenticatedUser = await this._authenticationService.RefreshAsync(token);

            if (authenticatedUser == null)
            {
                return Unauthorized();
            } 

            return Ok(authenticatedUser);
        }
    }
} 