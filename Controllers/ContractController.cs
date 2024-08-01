using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetContracts()
        {
            List<Contract> contracts = await _context.Contracts.ToListAsync();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract(int id)
        {
            Contract contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContract(CreateContractDTO model)
        {
            var contract = new Contract { CreatedAt = DateTime.UtcNow, StartDate = model.StartDate, EndDate = model.EndDate, Title = model.Title, Content = model.Content, UpdatedAt = DateTime.UtcNow, CreatedBy = 1 };

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return Ok(contract);
        }

        [HttpPut("{id}")]
        //TODO: implement this
        public async Task<IActionResult> UpdateContract()
        {
            return Ok();
        }
    }
}
