namespace MetaCRM.API.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public int? TeacherId { get; set; }
        public User? Teacher { get; set; }
        public string Schedule { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}