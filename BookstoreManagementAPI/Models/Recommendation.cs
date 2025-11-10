using System.ComponentModel.DataAnnotations;

namespace OnlineBookstoreManagementAPI.Models
{
    public class Recommendation
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public RecommendationType Type { get; set; }

        public double Score { get; set; }

        public string? Reason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }

    public enum RecommendationType
    {
        BasedOnPurchaseHistory = 0,
        BasedOnSimilarUsers = 1,
        BasedOnCategory = 2,
        BasedOnAuthor = 3,
        Trending = 4,
        NewRelease = 5,
        Featured = 6
    }
}
