using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Services
{
    public interface IAnalyticsService
    {
        Task<SalesReport> GetSalesReportAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BookSalesReport>> GetTopSellingBooksAsync(DateTime startDate, DateTime endDate, int count = 10);
        Task<IEnumerable<CategoryReport>> GetCategoryReportAsync(DateTime startDate, DateTime endDate);
        Task<Dictionary<string, decimal>> GetRevenueByMonthAsync(int year);
        Task<Dictionary<string, int>> GetOrdersByMonthAsync(int year);
        Task<Dictionary<string, int>> GetNewUsersByMonthAsync(int year);
        Task<decimal> GetTotalRevenueAsync();
        Task<int> GetTotalOrdersAsync();
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalBooksAsync();
        Task<decimal> GetAverageOrderValueAsync();
        Task UpdateAnalyticsAsync();
    }
}
