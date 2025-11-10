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
                TempData["ErrorMessage"] = "Book not found.";
                return RedirectToAction("Index", "Home");
            }

            if (quantity <= 0)
            {
                TempData["ErrorMessage"] = "Quantity must be a positive number.";
                return RedirectToAction("BookDetails", "Home", new { id = bookId });
            }

            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.BookId == bookId);

            int quantityInCart = cartItem?.Quantity ?? 0;

            if ((quantityInCart + quantity) > book.StockQuantity)
            {
                TempData["ErrorMessage"] = $"Sorry, you cannot add {quantity} more copies of '{book.Title}'. You already have {quantityInCart} in your cart, and we only have {book.StockQuantity} available.";
                return RedirectToAction("BookDetails", "Home", new { id = bookId });
            }

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
            TempData["SuccessMessage"] = $"Added {quantity} x '{book.Title}' to your cart.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int bookId, int quantity)
        {
            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.BookId == bookId);

            if (cartItem != null)
            {
                if (quantity > 0)
                {
                    cartItem.Quantity = quantity;
                }
                else
                {
                    cart.Items.Remove(cartItem);
                }
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int bookId)
        {
            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.BookId == bookId);
            if (cartItem != null)
            {
                cart.Items.Remove(cartItem);
                SaveCart(cart);
                TempData["SuccessMessage"] = $"Removed '{cartItem.BookTitle}' from your cart.";
            }
            return RedirectToAction("Index");
        }

        private CartViewModel GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new CartViewModel();
            }
            return JsonSerializer.Deserialize<CartViewModel>(cartJson) ?? new CartViewModel();
        }

        private void SaveCart(CartViewModel cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CartSessionKey, cartJson);
        }
    }
}