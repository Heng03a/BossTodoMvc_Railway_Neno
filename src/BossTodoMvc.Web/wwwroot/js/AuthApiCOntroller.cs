using Microsoft.AspNetCore.Mvc;
using BossTodoMvc.Application.Services;
using BossTodoMvc.Application.DTOs;

namespace BossTodoMvc.Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthApiController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _config;

        public AuthApiController(AuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest(new { message = "Missing credentials" });

            var expectedUser = _config["DemoAuth:Username"];
            var expectedPass = _config["DemoAuth:Password"];

            if (req.Username != expectedUser || req.Password != expectedPass)
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _authService.GenerateToken(req.Username);
            return Ok(new { token });
        }
    }
}
