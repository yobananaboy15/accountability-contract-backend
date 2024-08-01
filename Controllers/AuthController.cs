using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AccountabilityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccountabilityAppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthController(AccountabilityAppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var user = new User
            {
                Email = model.Email,

            };
            user.Password = _passwordHasher.HashPassword(user, model.Password);


            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.Email == model.Email);
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, model.Password) != PasswordVerificationResult.Success)
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            return Ok(new { Message = "Logged in" });
        }

    }
}
