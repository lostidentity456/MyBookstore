using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagementAPI.Models;
using OnlineBookstoreManagementAPI.Services;

namespace OnlineBookstoreManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,StoreOwner")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly ILogger<AnalyticsController> _logger;

        public AnalyticsController(IAnalyticsService analyticsService, ILogger<AnalyticsController> logger)
        {
            _analyticsService = analyticsService;
            _logger = logger;
        }

        /// <summary>
        /// Get sales report for a date range
        /// </summary>
        [HttpGet("sales-report")]
        public async Task<ActionResult<SalesReport>> GetSalesReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var report = await _analyticsService.GetSalesReportAsync(startDate, endDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sales report");
                return StatusCode(500, "An error occurred while generating the sales report");
            }
        }

        /// <summary>
        /// Get top selling books
        /// </summary>
        [HttpGet("top-selling-books")]
        public async Task<ActionResult<IEnumerable<BookSalesReport>>> GetTopSellingBooks(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate, 
            [FromQuery] int count = 10)
        {
            try
            {
                var books = await _analyticsService.GetTopSellingBooksAsync(startDate, endDate, count);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting top selling books");
                return StatusCode(500, "An error occurred while retrieving top selling books");
            }
        }

        /// <summary>
        /// Get category report
        /// </summary>
        [HttpGet("category-report")]
        public async Task<ActionResult<IEnumerable<CategoryReport>>> GetCategoryReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var report = await _analyticsService.GetCategoryReportAsync(startDate, endDate);
                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating category report");
                return StatusCode(500, "An error occurred while generating the category report");
            }
        }

        /// <summary>
        /// Get revenue by month for a year
        /// </summary>
        [HttpGet("revenue-by-month/{year}")]
        public async Task<ActionResult<Dictionary<string, decimal>>> GetRevenueByMonth(int year)
        {
            try
            {
                var revenue = await _analyticsService.GetRevenueByMonthAsync(year);
                return Ok(revenue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting revenue by month for year {Year}", year);
                return StatusCode(500, "An error occurred while retrieving revenue data");
            }
        }

        /// <summary>
        /// Get orders by month for a year
        /// </summary>
        [HttpGet("orders-by-month/{year}")]
        public async Task<ActionResult<Dictionary<string, int>>> GetOrdersByMonth(int year)
        {
            try
            {
                var orders = await _analyticsService.GetOrdersByMonthAsync(year);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders by month for year {Year}", year);
                return StatusCode(500, "An error occurred while retrieving orders data");
            }
        }

        /// <summary>
        /// Get new users by month for a year
        /// </summary>
        [HttpGet("new-users-by-month/{year}")]
        public async Task<ActionResult<Dictionary<string, int>>> GetNewUsersByMonth(int year)
        {
            try
            {
                var users = await _analyticsService.GetNewUsersByMonthAsync(year);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting new users by month for year {Year}", year);
                return StatusCode(500, "An error occurred while retrieving users data");
            }
        }

        /// <summary>
        /// Get dashboard summary
        /// </summary>
        [HttpGet("dashboard-summary")]
        public async Task<ActionResult<object>> GetDashboardSummary()
        {
            try
            {
                var totalRevenue = await _analyticsService.GetTotalRevenueAsync();
                var totalOrders = await _analyticsService.GetTotalOrdersAsync();
                var totalUsers = await _analyticsService.GetTotalUsersAsync();
                var totalBooks = await _analyticsService.GetTotalBooksAsync();
                var averageOrderValue = await _analyticsService.GetAverageOrderValueAsync();

                return Ok(new
                {
                    totalRevenue,
                    totalOrders,
                    totalUsers,
                    totalBooks,
                    averageOrderValue
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting dashboard summary");
                return StatusCode(500, "An error occurred while retrieving dashboard summary");
            }
        }

        /// <summary>
        /// Update analytics data
        /// </summary>
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAnalytics()
        {
            try
            {
                await _analyticsService.UpdateAnalyticsAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating analytics");
                return StatusCode(500, "An error occurred while updating analytics");
            }
        }
    }
}
