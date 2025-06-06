using Microsoft.AspNetCore.Mvc;
using WebMarket.Data;
using WebMarket.DTOs;
using WebMarket.Services;

namespace WebMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public AuthController(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = _authService.Register(registerDto);

            if (!registerResult.Success)
                return BadRequest(new { message = registerResult.Message });

            return Ok(new { message = registerResult.Message });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var loginResult = _authService.Login(loginDto);

            if (!loginResult.Success)
                return BadRequest(new { message = loginResult.Message });

            HttpContext.Session.SetInt32("UserId", loginResult.UserId.Value);

            return Ok(new { message = loginResult.Message });
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return Unauthorized(new { message = "Користувач не авторизований" });

            var userDto = _authService.GetCurrentUser(userId.Value);
            if (userDto == null)
                return NotFound(new { message = "Користувача не знайдено" });

            return Ok(userDto);
        }
    }
}