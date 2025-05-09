using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Wallet.API.Models.Request;
using Wallet.Application.Interfaces;

namespace Wallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                    return BadRequest("El nombre de usuario y la contraseña son obligatorios.");

                var token = await _authenticationService.RegisterAsync(request.Username, request.Password, request.Email, request.DocumentId);
                return Ok(new { Token = token });
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
            
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");

            try
            {
                var token = await _authenticationService.LoginAsync(request.Username, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }
    }
}
