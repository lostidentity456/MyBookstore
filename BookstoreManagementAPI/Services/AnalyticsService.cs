using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<AnalyticsService> _logger;

        public AnalyticsService(BookstoreDbContext context, ILogger<AnalyticsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<SalesReport> GetSalesReportAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var orders = await _context.Orders
                    .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                    .ToListAsync();

                var totalSales = orders.Sum(o => o.TotalAmount);
                var totalOrders = orders.Count;
                var totalBooksSold = await _context.OrderItems
                    .Where(oi => oi.Order.CreatedAt >= startDate && oi.Order.CreatedAt <= endDate)
                    .SumAsync(oi => oi.Quantity);

                var newCustomers = await _context.Users
                    .Where(u => u.CreatedAt >= startDate && u.CreatedAt <= endDate)
                    .CountAsync();

                var averageOrderValue = totalOrders > 0 ? totalSales / totalOrders : 0;

                return new SalesReport
                {
                    Date = DateTime.UtcNow,
                    TotalSales = totalSales,
                    TotalOrders = totalOrders,
                    TotalBooksSold = totalBooksSold,
                    NewCustomers = newCustomers,
                    AverageOrderValue = averageOrderValue
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sales report");
                return new SalesReport();
            }
        }

        public async Task<IEnumerable<BookSalesReport>> GetTopSellingBooksAsync(DateTime startDate, DateTime endDate, int count = 10)
        {
            try
            {
                var bookSales = await _context.OrderItems
                    .Include(oi => oi.Book)
                        .ThenInclude(b => b.Author)
                    .Include(oi => oi.Book)
                        .ThenInclude(b => b.Category)
                    .Where(oi => oi.Order.CreatedAt >= startDate && oi.Order.CreatedAt <= endDate)
                    .GroupBy(oi => oi.BookId)
                    .Select(g => new BookSalesReport
                    {
                        BookId = g.Key,
                        BookTitle = g.First().Book.Title,
                        AuthorName = g.First().Book.Author.FullName,
                        CategoryName = g.First().Book.Category.Name,
                        QuantitySold = g.Sum(oi => oi.Quantity),
                        TotalRevenue = g.Sum(oi => oi.TotalPrice),
                        AveragePrice = g.Average(oi => oi.UnitPrice)
                    })
                    .OrderByDescending(bs => bs.QuantitySold)
                    .Take(count)
                    .ToListAsync();

                return bookSales;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting top selling books");
                return new List<BookSalesReport>();
            }
        }

        public async Task<IEnumerable<CategoryReport>> GetCategoryReportAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var categoryReports = await _context.Categories
                    .Select(c => new CategoryReport
                    {
                        CategoryId = c.Id,
                        CategoryName = c.Name,
                        BookCount = c.Books.Count(b => b.IsActive),
                        TotalSales = c.Books
                            .SelectMany(b => b.OrderItems)
                            .Where(oi => oi.Order.CreatedAt >= startDate && oi.Order.CreatedAt <= endDate)
                            .Sum(oi => oi.Quantity),
                        TotalRevenue = c.Books
                            .SelectMany(b => b.OrderItems)
                            .Where(oi => oi.Order.CreatedAt >= startDate && oi.Order.CreatedAt <= endDate)
                            .Sum(oi => oi.TotalPrice),
                        AverageRating = c.Books
                            .Where(b => b.AverageRating > 0)
                            .Average(b => b.AverageRating)
                    })
                    .Where(cr => cr.TotalSales > 0)
                    .OrderByDescending(cr => cr.TotalRevenue)
                    .ToListAsync();

                return categoryReports;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting category report");
                return new List<CategoryReport>();
            }
        }

        public async Task<Dictionary<string, decimal>> GetRevenueByMonthAsync(int year)
        {
            try
            {
                var revenueByMonth = await _context.Orders
                    .Where(o => o.CreatedAt.Year == year && o.PaymentStatus == OrderPaymentStatus.Paid)
                    .GroupBy(o => o.CreatedAt.Month)
                    .Select(g => new { Month = g.Key, Revenue = g.Sum(o => o.TotalAmount) })
                    .ToListAsync();

                var result = new Dictionary<string, decimal>();
                for (int month = 1; month <= 12; month++)
                {
                    var monthData = revenueByMonth.FirstOrDefault(r => r.Month == month);
                    result[GetMonthName(month)] = monthData?.Revenue ?? 0;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting revenue by month for year {Year}", year);
                return new Dictionary<string, decimal>();
            }
        }

        public async Task<Dictionary<string, int>> GetOrdersByMonthAsync(int year)
        {
            try
            {
                var ordersByMonth = await _context.Orders
                    .Where(o => o.CreatedAt.Year == year)
                    .GroupBy(o => o.CreatedAt.Month)
                    .Select(g => new { Month = g.Key, Count = g.Count() })
                    .ToListAsync();

                var result = new Dictionary<string, int>();
                for (int month = 1; month <= 12; month++)
                {
                    var monthData = ordersByMonth.FirstOrDefault(o => o.Month == month);
                    result[GetMonthName(month)] = monthData?.Count ?? 0;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders by month for year {Year}", year);
                return new Dictionary<string, int>();
            }
        }

        public async Task<Dictionary<string, int>> GetNewUsersByMonthAsync(int year)
        {
            try
            {
                var usersByMonth = await _context.Users
                    .Where(u => u.CreatedAt.Year == year)
                    .GroupBy(u => u.CreatedAt.Month)
                    .Select(g => new { Month = g.Key, Count = g.Count() })
                    .ToListAsync();

                var result = new Dictionary<string, int>();
                for (int month = 1; month <= 12; month++)
                {
                    var monthData = usersByMonth.FirstOrDefault(u => u.Month == month);
                    result[GetMonthName(month)] = monthData?.Count ?? 0;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting new users by month for year {Year}", year);
                return new Dictionary<string, int>();
            }
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            try
            {
                return await _context.Orders
                    .Where(o => o.PaymentStatus == OrderPaymentStatus.Paid)
                    .SumAsync(o => o.TotalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total revenue");
                return 0;
            }
        }

        public async Task<int> GetTotalOrdersAsync()
        {
            try
            {
                return await _context.Orders.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total orders");
                return 0;
            }
        }

        public async Task<int> GetTotalUsersAsync()
        {
            try
            {
                return await _context.Users.CountAsync(u => u.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total users");
                return 0;
            }
        }

        public async Task<int> GetTotalBooksAsync()
        {
            try
            {
                return await _context.Books.CountAsync(b => b.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total books");
                return 0;
            }
        }

        public async Task<decimal> GetAverageOrderValueAsync()
        {
            try
            {
                var orders = await _context.Orders
                    .Where(o => o.PaymentStatus == OrderPaymentStatus.Paid)
                    .ToListAsync();

                return orders.Any() ? orders.Average(o => o.TotalAmount) : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting average order value");
                return 0;
            }
        }

        public async Task UpdateAnalyticsAsync()
        {
            try
            {
                var today = DateTime.UtcNow.Date;
                
                // Update daily analytics
                await UpdateDailyAnalytics(today);
                
                // Update monthly analytics
                await UpdateMonthlyAnalytics(today);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating analytics");
            }
        }

        private async Task UpdateDailyAnalytics(DateTime date)
        {
            var startOfDay = date;
            var endOfDay = date.AddDays(1);

            var salesReport = await GetSalesReportAsync(startOfDay, endOfDay);

            // Update or create analytics records
            var existingAnalytics = await _context.Analytics
                .Where(a => a.Date == date)
                .ToListAsync();

            _context.Analytics.RemoveRange(existingAnalytics);

            var newAnalytics = new List<Analytics>
            {
                new Analytics { MetricName = "Daily Revenue", Value = salesReport.TotalSales, Date = date, Type = AnalyticsType.Revenue },
                new Analytics { MetricName = "Daily Orders", Value = salesReport.TotalOrders, Date = date, Type = AnalyticsType.Orders },
                new Analytics { MetricName = "Daily Books Sold", Value = salesReport.TotalBooksSold, Date = date, Type = AnalyticsType.Sales },
                new Analytics { MetricName = "Daily New Users", Value = salesReport.NewCustomers, Date = date, Type = AnalyticsType.Users },
                new Analytics { MetricName = "Daily Average Order Value", Value = salesReport.AverageOrderValue, Date = date, Type = AnalyticsType.Sales }
            };

            _context.Analytics.AddRange(newAnalytics);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateMonthlyAnalytics(DateTime date)
        {
            var startOfMonth = new DateTime(date.Year, date.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            var salesReport = await GetSalesReportAsync(startOfMonth, endOfMonth);

            // Update monthly analytics
            var existingMonthlyAnalytics = await _context.Analytics
                .Where(a => a.Date == startOfMonth && a.MetricName.Contains("Monthly"))
                .ToListAsync();

            _context.Analytics.RemoveRange(existingMonthlyAnalytics);

            var monthlyAnalytics = new List<Analytics>
            {
                new Analytics { MetricName = "Monthly Revenue", Value = salesReport.TotalSales, Date = startOfMonth, Type = AnalyticsType.Revenue },
                new Analytics { MetricName = "Monthly Orders", Value = salesReport.TotalOrders, Date = startOfMonth, Type = AnalyticsType.Orders },
                new Analytics { MetricName = "Monthly Books Sold", Value = salesReport.TotalBooksSold, Date = startOfMonth, Type = AnalyticsType.Sales },
                new Analytics { MetricName = "Monthly New Users", Value = salesReport.NewCustomers, Date = startOfMonth, Type = AnalyticsType.Users }
            };

            _context.Analytics.AddRange(monthlyAnalytics);
            await _context.SaveChangesAsync();
        }

        private string GetMonthName(int month)
        {
            return new DateTime(2024, month, 1).ToString("MMM");
        }
    }
}
