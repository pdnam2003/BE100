using BE100.DTOs.Request;
using BE100.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE100.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {
            try
            {
                var result = await _authService.LoginAsync(dto);

                return Ok(new
                {
                    accessToken = result.AccessToken,
                    refreshToken = result.RefreshToken
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
