using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AccountabilityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccountabilityAppDbContext _context;
        public AuthController(AccountabilityAppDbContext context) { 
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {

        }

    }
}
