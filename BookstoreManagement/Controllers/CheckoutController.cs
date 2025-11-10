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

                    return RedirectToAction("Confirmation", new { id = createdOrder.Id });
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

        private CartViewModel GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            return string.IsNullOrEmpty(cartJson) ? new CartViewModel() : JsonSerializer.Deserialize<CartViewModel>(cartJson);
        }
    }
}