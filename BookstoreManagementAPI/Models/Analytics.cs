using System.ComponentModel.DataAnnotations;

namespace OnlineBookstoreManagementAPI.Models
{
    public class Analytics
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string MetricName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public decimal Value { get; set; }

        public string? Unit { get; set; }

        public DateTime Date { get; set; }

        public AnalyticsType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum AnalyticsType
    {
        Sales = 0,
        Revenue = 1,
        Orders = 2,
        Users = 3,
        Books = 4,
        Inventory = 5,
        Performance = 6
    }

    public class SalesReport
    {
        public DateTime Date { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public int TotalBooksSold { get; set; }
        public int NewCustomers { get; set; }
        public decimal AverageOrderValue { get; set; }
    }

    public class BookSalesReport
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AveragePrice { get; set; }
    }

    public class CategoryReport
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int BookCount { get; set; }
        public int TotalSales { get; set; }
        public decimal TotalRevenue { get; set; }
        public double AverageRating { get; set; }
    }
}
