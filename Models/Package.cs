namespace WebApplication_Deneme.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Relationship
        public ICollection<Payment> Payments { get; set; }
    }
}
