using Microsoft.AspNetCore.Mvc;
using ReoNet.Api.Models.Auth;
using ReoNet.Api.Services;

namespace ReoNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            try
            {
                var user = await _authService.RegisterAsync(
                    model.Username,
                    model.Password,
                    model.Email,
                    model.FirstName,
                    model.LastName
                );

                return Ok(
                    new
                    {
                        message = "User registered successfully",
                        userId = user.Srl,
                        username = user.Username
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _authService.LoginAsync(model.Email, model.Password);

            if (user == null)
                return Unauthorized(new { error = "Invalid credentials" });

            var token = _jwtService.GenerateToken(user);

            return Ok(
                new
                {
                    message = "Login successful",
                    token,
                    userId = user.Srl,
                    username = user.Username,
                    email = user.Email,
                    srl_customer = user.SrlCustomer,
                    is_admin = user.IsActive
                }
            );
        }
    }
}
