namespace MetaCRM.API.Models
{
    public enum OrgType
    {
        CourseCenter,
        School,
        Kindergarten
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public OrgType Type { get; set; } = OrgType.CourseCenter;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Navigation
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}