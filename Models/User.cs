using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Deneme.Models
{
    public class User: IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
        // "Admin", "Teacher", "Student"

        // Relationships
        public ICollection<TeacherBranch> TeacherBranches { get; set; } = new List<TeacherBranch>();
        public ICollection<Appointment> AppointmentsAsStudent { get; set; } = new List<Appointment>();
        public ICollection<Appointment> AppointmentsAsTeacher { get; set; } = new List<Appointment>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public ICollection<Course> CoursesAsTeacher { get; set; } = new List<Course>();
        public ICollection<CourseEnrollment> EnrolledCourses { get; set; } = new List<CourseEnrollment>();
        public ICollection<CourseMaterial> UploadedMaterials { get; set; } = new List<CourseMaterial>();

    }
}
