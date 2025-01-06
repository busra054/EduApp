using System.ComponentModel.DataAnnotations;

namespace WebApplication_Deneme.Models
{
    public class CourseEnrollment
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }

        // Relationships
        public Course Course { get; set; }
        public User Student { get; set; }
    }

}
