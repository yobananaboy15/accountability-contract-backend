using System.Reflection.Metadata;

namespace AccountabilityApp.Models
{
    public class Signature
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        public int? UserId { get; set; }
        public User User { get; set; }  // Navigation property to User (optional)
        public DateTime? SignedDate { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
