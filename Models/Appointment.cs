using System.ComponentModel.DataAnnotations;

namespace WebApplication_Deneme.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        // Relationships
        public User Student { get; set; }
        public User Teacher { get; set; }
    }
}
