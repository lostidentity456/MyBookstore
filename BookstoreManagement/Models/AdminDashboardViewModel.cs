namespace OnlineBookstoreManagement.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalBooks { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCategories { get; set; }
        public int TotalUsers { get; set; }
        public decimal TotalRevenue { get; set; }
        public List<OrderViewModel> RecentOrders { get; set; } = new List<OrderViewModel>();
        public List<BookViewModel> LowStockBooks { get; set; } = new List<BookViewModel>();
        public List<BookViewModel> TopSellingBooks { get; set; } = new List<BookViewModel>();
    }

    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int OrderCount { get; set; }
    }
}
