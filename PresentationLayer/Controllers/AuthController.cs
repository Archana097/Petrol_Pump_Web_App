using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petrol_Pump_Web_API.ApplicationLayer.DTOS;
using Petrol_Pump_Web_API.ApplicationLayer.Services;

namespace Petrol_Pump_Web_API.PresentationLayer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {

            var token = await _auth.Authenticate(dto.Username,dto.Password);

            return Ok(new
            {
                token = token
            });

        }
    }
}
