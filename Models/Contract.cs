namespace AccountabilityApp.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt {  get; set; } 
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public List<Signature> Signatures { get; set; }

    }
}
