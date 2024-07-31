using AccountabilityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountabilityApp.Data
{
    public class AccountabilityAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AccountabilityAppDbContext(DbContextOptions<AccountabilityAppDbContext> options) : base(options) { }
    }
}