using System.ComponentModel.DataAnnotations;

namespace WebApplication_Deneme.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Relationships
        public ICollection<Payment> Payments { get; set; }
    }
}
