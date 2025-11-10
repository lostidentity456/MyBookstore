using System.ComponentModel.DataAnnotations;

namespace OnlineBookstoreManagementAPI.Models
{
    public class WishlistItem
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}
