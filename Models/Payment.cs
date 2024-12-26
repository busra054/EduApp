namespace WebApplication_Deneme.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        // Relationships
        public User User { get; set; }
        public Package Package { get; set; }
    }
}
