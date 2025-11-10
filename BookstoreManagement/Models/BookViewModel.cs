using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineBookstoreManagement.Models
{
    public class BookViewModel
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

    public class BookListViewModel
    {
        public List<BookViewModel> Books { get; set; } = new List<BookViewModel>();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public List<AuthorViewModel> Authors { get; set; } = new List<AuthorViewModel>();
        public string? SearchTerm { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 12;
        public SelectList? CategoryList { get; set; }
        public SelectList? AuthorList { get; set; }
    }
}
