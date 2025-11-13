using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;
using System.Text.Json;

namespace OnlineBookstoreManagement.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IApiService _apiService;
        private const string CartSessionKey = "Cart";

        public CheckoutController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            if (!cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var model = new CreateOrderViewModel();
            model.OrderItems = cart.Items.Select(item => new CreateOrderItemViewModel
            {
                BookId = item.BookId,
                Quantity = item.Quantity
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateOrderViewModel model)
        {
            var cart = GetCart();
            if (!cart.Items.Any())
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return View(model);
            }

            // **NEW: Validate stock availability before processing**
            var stockValidation = await ValidateStockAvailability(cart.Items);
            if (!stockValidation.IsValid)
            {
                foreach (var error in stockValidation.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.OrderItems = cart.Items.Select(item => new CreateOrderItemViewModel
                {
                    BookId = item.BookId,
                    Quantity = item.Quantity
                }).ToList();

                try
                {
                    var createdOrder = await _apiService.CreateOrderAsync(model);
                    HttpContext.Session.Remove(CartSessionKey);

                    // Redirect to payment step
                    return RedirectToAction("Pay", "Payments", new { orderId = createdOrder.Id, amount = createdOrder.TotalAmount });
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", "There was an error placing your order: " + ex.Message);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var order = await _apiService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // **NEW: Stock validation method**
        private async Task<StockValidationResult> ValidateStockAvailability(List<CartItemViewModel> cartItems)
        {
            var result = new StockValidationResult { IsValid = true, Errors = new List<string>() };

            foreach (var item in cartItems)
            {
                try
                {
                    var book = await _apiService.GetBookByIdAsync(item.BookId);
                    if (book == null)
                    {
                        result.IsValid = false;
                        result.Errors.Add($"Book with ID {item.BookId} not found.");
                        continue;
                    }

                    if (book.StockQuantity < item.Quantity)
                    {
                        result.IsValid = false;
                        result.Errors.Add($"Insufficient stock for '{book.Title}'. Available: {book.StockQuantity}, Requested: {item.Quantity}");
                        continue;
                    }

                    if (book.StockQuantity == 0)
                    {
                        result.IsValid = false;
                        result.Errors.Add($"'{book.Title}' is currently out of stock.");
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    result.IsValid = false;
                    result.Errors.Add($"Error checking stock for book ID {item.BookId}: {ex.Message}");
                }
            }

            return result;
        }

        // **NEW: Ajax endpoint for real-time stock checking**
        [HttpPost]
        public async Task<JsonResult> CheckStock()
        {
            var cart = GetCart();
            var stockValidation = await ValidateStockAvailability(cart.Items);

            return Json(new
            {
                isValid = stockValidation.IsValid,
                errors = stockValidation.Errors
            });
        }

        private CartViewModel GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            return string.IsNullOrEmpty(cartJson) ? new CartViewModel() : JsonSerializer.Deserialize<CartViewModel>(cartJson);
        }
    }

    public class StockValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}