namespace OnlineBookstoreManagement.Models
{
    public class StatisticsDto
    {
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int ShippedOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal RevenueLast30Days { get; set; }

        public int TotalBooks { get; set; }
        public int BooksInStock { get; set; }
        public int BooksOutOfStock { get; set; }
        public BookDto TopSellingBook { get; set; }

        public int TotalCustomers { get; set; }
        public int NewCustomersLast30Days { get; set; }
    }
}
