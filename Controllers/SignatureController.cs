using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (contract == null) {
                return BadRequest();
            }

            if(contract.CreatedBy != userId)
            {
                return Unauthorized();
            }

            //TODO: add logic for signing from 
            _context.Signatures.Add(new Signature { ContractId = contract.Id, UserId = userId });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

