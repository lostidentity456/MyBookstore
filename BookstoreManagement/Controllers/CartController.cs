using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;
using System.Text.Json;

namespace OnlineBookstoreManagement.Controllers
{
    public class CartController : Controller
    {
        private readonly IApiService _apiService;
        private const string CartSessionKey = "Cart";

        public CartController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int bookId, int quantity = 1)
        {
            var book = await _apiService.GetBookByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.BookId == bookId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItemViewModel
                {
                    BookId = book.Id,
                    BookTitle = book.Title,
                    ImageUrl = book.ImageUrl,
                    Price = book.CurrentPrice,
                    Quantity = quantity
                });
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        private CartViewModel GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new CartViewModel();
            }
            return JsonSerializer.Deserialize<CartViewModel>(cartJson);
        }

        private void SaveCart(CartViewModel cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CartSessionKey, cartJson);
        }
    }
}