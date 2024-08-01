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
        //
    }
}
