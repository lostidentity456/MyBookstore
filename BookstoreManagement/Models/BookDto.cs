using System.ComponentModel.DataAnnotations;

namespace OnlineBookstoreManagement.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Language { get; set; } = string.Empty;
        public int NumberOfPages { get; set; }
        public string? Edition { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsInStock { get; set; }
        public bool IsLowStock { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
    }

    public class CreateBookDto
    {
        [Required(ErrorMessage = "The book title is required.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 255 characters.")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "The ISBN is required.")]
        [RegularExpression(@"^(?:ISBN(?:-13)?:?)(?=[0-9]{13}$)([0-9]{3}-){2}[0-9]{3}[0-9X]$", ErrorMessage = "Invalid ISBN-13 format.")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "The publisher is required.")]
        [StringLength(100)]
        public string Publisher { get; set; } = string.Empty;

        [Required]
        public DateTime PublicationDate { get; set; }

        [StringLength(50)]
        public string Language { get; set; } = "English";

        [Range(1, 5000, ErrorMessage = "Number of pages must be between 1 and 5000.")]
        public int NumberOfPages { get; set; }

        public string? Edition { get; set; }

        [Url(ErrorMessage = "The image URL must be a valid URL.")]
        public string? ImageUrl { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00.")]
        public decimal Price { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Discount price must be between 0.01 and 10000.00.")]
        public decimal? DiscountPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int StockQuantity { get; set; } = 0;

        [Range(0, int.MaxValue, ErrorMessage = "Minimum stock level cannot be negative.")]
        public int MinStockLevel { get; set; } = 5;

        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; } = false;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A valid category ID is required.")]
        public int CategoryId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A valid author ID is required.")]
        public int AuthorId { get; set; }
    }

    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Language { get; set; } = "English";
        public int NumberOfPages { get; set; }
        public string? Edition { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockLevel { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
