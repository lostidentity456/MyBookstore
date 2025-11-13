using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;

namespace OnlineBookstoreManagement.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IApiService apiService, ILogger<OrderController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                var success = await _apiService.CancelOrderAsync(id);
                if (success)
                {
                    TempData["SuccessMessage"] = "Order cancelled successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Unable to cancel the order.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling order {OrderId}", id);
                TempData["ErrorMessage"] = "An error occurred while cancelling the order.";
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var orders = await _apiService.GetOrdersAsync();
                return View(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading orders");
                return View(new List<OrderViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var order = await _apiService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound();
                }

                return View(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading order details for ID {OrderId}", id);
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = await _apiService.CreateOrderAsync(model);
                    TempData["SuccessMessage"] = "Order placed successfully!";
                    return RedirectToAction("Details", new { id = order.Id });
                }

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                ModelState.AddModelError("", "An error occurred while creating the order. Please try again.");
                return View(model);
            }
        }
    }
}
