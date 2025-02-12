using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoventIQ.UserMgmt;
using NoventIQ.UserMgmt.Models;
using NoventIQ.UserMgmt.Services;


namespace NoventIQ.UserMgmt.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;

        public AuthController(AppDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null || user.PasswordHash != request.Password) // Replace with hash verification
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _authService.GenerateJwtToken(user);
            return Ok(new AuthResponse { Token = token, Expiration = DateTime.UtcNow.AddHours(1) });
        }

    }
}
