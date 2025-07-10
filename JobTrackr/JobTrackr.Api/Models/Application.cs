namespace JobTrackr.Api.Models
{
    public class Application
    {
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Stage { get; set; } = "Applied"; // E.g. Applied, Interview, Offer, Rejected
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
        public string Location { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
