namespace AccountabilityApp.Models
{
    public class Signature
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int? UserId { get; set; }
        public DateTime? SignedDate { get; set; }

        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
