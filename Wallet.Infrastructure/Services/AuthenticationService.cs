

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wallet.Application.Interfaces;
using Wallet.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Wallet.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthenticationService (UserManager<User> userManager, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || !user.isActive)
                throw new UnauthorizedAccessException("Usuario no encontrado o inactivo.");

            
            var validPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!validPassword)
                throw new UnauthorizedAccessException("Credenciales incorrectas.");

            // Generar el token JWT
            return await _tokenService.GenerateJwtToken(user);
        }

        public async Task<string> RegisterAsync(string username, string password, string email, string documentId)
        {
            var user = new User
            {
                UserName = username,
                Email = email,
                documentId = documentId,
                isActive = true
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("No se pudo crear el usuario: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            
            return await _tokenService.GenerateJwtToken(user);
        }

    }
}
