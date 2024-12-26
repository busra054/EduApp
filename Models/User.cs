namespace WebApplication_Deneme.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        // Relationships
        public ICollection<TeacherBranch> TeacherBranches { get; set; }
        public ICollection<Appointment> AppointmentsAsStudent { get; set; }
        public ICollection<Appointment> AppointmentsAsTeacher { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
