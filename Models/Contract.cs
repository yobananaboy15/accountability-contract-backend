namespace AccountabilityApp.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedAt { get; set; }
    }
}
