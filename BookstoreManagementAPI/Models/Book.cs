using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookstoreManagementAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Publisher { get; set; } = string.Empty;

        public DateTime PublicationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; } = "English";

        public int NumberOfPages { get; set; }

        [StringLength(50)]
        public string? Edition { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? DiscountPrice { get; set; }

        public int StockQuantity { get; set; } = 0;

        public int MinStockLevel { get; set; } = 5;

        public bool IsActive { get; set; } = true;

        public bool IsFeatured { get; set; } = false;

        public double AverageRating { get; set; } = 0.0;

        public int TotalReviews { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Foreign Keys
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        // Navigation properties
        public virtual Category Category { get; set; } = null!;
        public virtual Author Author { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();

        // Computed properties
        public decimal CurrentPrice => DiscountPrice ?? Price;
        public bool IsInStock => StockQuantity > 0;
        public bool IsLowStock => StockQuantity <= MinStockLevel;
    }
}
