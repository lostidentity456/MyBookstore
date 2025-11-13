using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly BookstoreDbContext _context;
        private readonly IBookService _bookService; // Re-use the book service for DTO mapping

        public StatisticsService(BookstoreDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        public async Task<StatisticsDto> GetDashboardStatisticsAsync()
        {
            var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);

            // Order stats
            var totalOrders = await _context.Orders.CountAsync();
            var pendingOrders = await _context.Orders.CountAsync(o => o.Status == OrderStatus.Pending || o.Status == OrderStatus.Confirmed);
            var shippedOrders = await _context.Orders.CountAsync(o => o.Status == OrderStatus.Shipped);
            var totalRevenue = await _context.Orders.Where(o => o.PaymentStatus == OrderPaymentStatus.Paid).SumAsync(o => o.TotalAmount);
            var revenueLast30Days = await _context.Orders.Where(o => o.PaymentStatus == OrderPaymentStatus.Paid && o.CreatedAt >= thirtyDaysAgo).SumAsync(o => o.TotalAmount);

            // Book stats
            var totalBooks = await _context.Books.CountAsync(b => b.IsActive);
            var booksInStock = await _context.Books.CountAsync(b => b.IsActive && b.StockQuantity > 0);

            // User stats
            var totalCustomers = await _context.Users.CountAsync(u => u.Role == UserRole.Customer);
            var newCustomersLast30Days = await _context.Users.CountAsync(u => u.Role == UserRole.Customer && u.CreatedAt >= thirtyDaysAgo);

            // Top selling book (a more complex query)
            var topSellingBookInfo = await _context.OrderItems
                .GroupBy(oi => oi.BookId)
                .Select(g => new { BookId = g.Key, TotalQuantity = g.Sum(oi => oi.Quantity) })
                .OrderByDescending(x => x.TotalQuantity)
                .FirstOrDefaultAsync();

            BookDto topSellingBookDto = null;
            if (topSellingBookInfo != null)
            {
                topSellingBookDto = await _bookService.GetBookByIdAsync(topSellingBookInfo.BookId);
            }

            return new StatisticsDto
            {
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                ShippedOrders = shippedOrders,
                TotalRevenue = totalRevenue,
                RevenueLast30Days = revenueLast30Days,
                TotalBooks = totalBooks,
                BooksInStock = booksInStock,
                BooksOutOfStock = totalBooks - booksInStock,
                TopSellingBook = topSellingBookDto,
                TotalCustomers = totalCustomers,
                NewCustomersLast30Days = newCustomersLast30Days
            };
        }
    }
}