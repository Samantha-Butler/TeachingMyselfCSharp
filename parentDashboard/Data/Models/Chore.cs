namespace ParentDashboard.Data.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AssignedTo { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
    }
}
