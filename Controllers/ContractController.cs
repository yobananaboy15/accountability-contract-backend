using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AccountabilityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : Controller
    {
        private readonly AccountabilityAppDbContext _context;
        public ContractController(AccountabilityAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetContracts()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Contract> contracts = await _context.Contracts.Where(e => e.CreatedBy == userId).ToListAsync();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetContract(int id)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Contract contract = await _context.Contracts.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            //TODO: This needs to change later to be more flexible
            if (contract.CreatedBy != userId)
            {
                return Unauthorized();
            }

            return Ok(contract);
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateContract(CreateContractDTO model)

        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contract = new Contract { CreatedAt = DateTime.UtcNow, StartDate = model.StartDate, EndDate = model.EndDate, Title = model.Title, Content = model.Content, UpdatedAt = DateTime.UtcNow, CreatedBy = userId };

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return Ok(contract);
        }

        [HttpPut("{id}")]
        [Authorize]
        //TODO: implement this
        public async Task<IActionResult> UpdateContract()
        {
            return Ok();
        }

        [HttpGet("token/{token}")]
        public IActionResult GetContractByToken(string token)
        {
            var signature = _context.Signatures.FirstOrDefault(signature => signature.Token == token);
            if (signature == null || signature.SignedDate.HasValue || signature.ExpirationDate < DateTime.UtcNow)
            {
                return NotFound("Invalid, expired or already used token");
            }

            var contract = _context.Contracts.Find(signature.ContractId);
            if (contract == null)
            {
                return NotFound("Contract not found");
            }
            return Ok(contract);
        }
    }
}
