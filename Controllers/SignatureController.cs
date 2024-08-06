using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountabilityApp.Controllers
{
    [Route("api/[contoller]")]
    [ApiController]
    public class SignatureController : Controller
    {
        private readonly AccountabilityAppDbContext _context;
        public SignatureController(AccountabilityAppDbContext context)
        {

            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SignContract(int id)
        {
            Contract contract = await _context.Contracts.FindAsync(id);

            if (contract == null) {
                return NotFound();
            }
        }
    }
}

