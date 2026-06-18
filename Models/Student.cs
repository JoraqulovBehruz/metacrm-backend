using System.Text.RegularExpressions;

namespace MetaCRM.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}