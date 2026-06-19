namespace MetaCRM.API.Models
{
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Overdue
    }

    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string? Description { get; set; }
        public string? PayedBy { get; set; }
    }
}