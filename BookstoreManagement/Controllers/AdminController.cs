using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;

namespace OnlineBookstoreManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IApiService apiService, ILogger<AdminController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var isAuthenticated = await _apiService.IsAuthenticatedAsync();
            if (!isAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                // Get dashboard statistics
                var books = await _apiService.GetBooksAsync();
                var orders = await _apiService.GetOrdersAsync();
                var categories = await _apiService.GetCategoriesAsync();

                var model = new AdminDashboardViewModel
                {
                    TotalBooks = books.Count,
                    TotalOrders = orders.Count,
                    TotalCategories = categories.Count,
                    RecentOrders = orders.Take(5).ToList(),
                    LowStockBooks = books.Where(b => b.IsLowStock).Take(5).ToList()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading admin dashboard");
                return View(new AdminDashboardViewModel());
            }
        }

        public async Task<IActionResult> Books()
        {
            var isAuthenticated = await _apiService.IsAuthenticatedAsync();
            if (!isAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                var books = await _apiService.GetBooksAsync();
                var categories = await _apiService.GetCategoriesAsync();
                var authors = await _apiService.GetAuthorsAsync();

                var model = new BookListViewModel
                {
                    Books = books,
                    Categories = categories,
                    Authors = authors
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading admin books page");
                return View(new BookListViewModel());
            }
        }

        public async Task<IActionResult> Orders()
        {
            var isAuthenticated = await _apiService.IsAuthenticatedAsync();
            if (!isAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                var orders = await _apiService.GetOrdersAsync();
                return View(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading admin orders page");
                return View(new List<OrderViewModel>());
            }
        }

        public async Task<IActionResult> Users()
        {
            var isAuthenticated = await _apiService.IsAuthenticatedAsync();
            if (!isAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                // This would need to be implemented in the API service
                // For now, return empty list
                var users = new List<UserViewModel>();
                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading admin users page");
                return View(new List<UserViewModel>());
            }
        }
    }
}
