using AccountabilityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountabilityApp.Data
{
    public class AccountabilityAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Signature> Signatures { get; set; }

        public AccountabilityAppDbContext(DbContextOptions<AccountabilityAppDbContext> options) : base(options) { }
    }
}