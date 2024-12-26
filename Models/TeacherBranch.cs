namespace WebApplication_Deneme.Models
{
    public class TeacherBranch
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int BranchId { get; set; }

        // Relationships
        public User Teacher { get; set; }
        public Branch Branch { get; set; }
    }
}
