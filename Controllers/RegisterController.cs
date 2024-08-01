using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AccountabilityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AccountabilityAppDbContext _context;
        public RegisterController(AccountabilityAppDbContext context) { 
            _context = context;
        }

        //TODO: remove this, it's just here for testing purposes
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
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


    }
}
