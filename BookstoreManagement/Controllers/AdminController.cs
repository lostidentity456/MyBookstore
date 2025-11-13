using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;

namespace OnlineBookstoreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
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
            var books = await _apiService.GetBooksAsync();
            return View(books);
        }
        public async Task<IActionResult> Statistics()
        {
            try
            {
                var stats = await _apiService.GetDashboardStatisticsAsync();
                return View(stats);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error loading statistics dashboard.");
                return View(new StatisticsDto());
            }
        }


        public async Task<IActionResult> Create()
        {
            var viewModel = new BookFormViewModel
            {
                Authors = await _apiService.GetAuthorsAsync(),
                Categories = await _apiService.GetCategoriesAsync()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Orders()
        {
            try
            {
                var orders = await _apiService.GetAllOrdersAsync();
                return View(orders);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error loading admin orders page.");
                return View(new List<OrderViewModel>());
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(int id, UpdateOrderStatusDto dto)
        {
            if (dto == null)
            {
                TempData["ErrorMessage"] = "Invalid request.";
                return RedirectToAction(nameof(Orders));
            }

            var updated = await _apiService.UpdateOrderStatusAsync(id, dto);
            if (updated == null)
            {
                TempData["ErrorMessage"] = "Failed to update order status.";
            }
            else
            {
                TempData["SuccessMessage"] = "Order status updated.";
            }
            return RedirectToAction(nameof(Orders));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.CreateBookAsync(viewModel.Book);
                    TempData["SuccessMessage"] = "Book created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, "Error creating book.");
                    ModelState.AddModelError("", "An error occurred while creating the book. Please try again.");
                }
            }

            viewModel.Authors = await _apiService.GetAuthorsAsync();
            viewModel.Categories = await _apiService.GetCategoriesAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _apiService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Authors = await _apiService.GetAuthorsAsync(),
                Categories = await _apiService.GetCategoriesAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookFormViewModel viewModel)
        {
            if (id != viewModel.Book.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.UpdateBookAsync(id, viewModel.Book);
                    TempData["SuccessMessage"] = "Book updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, "Error updating book with ID {BookId}", id);
                    ModelState.AddModelError("", "An error occurred while updating the book.");
                }
            }

            viewModel.Authors = await _apiService.GetAuthorsAsync();
            viewModel.Categories = await _apiService.GetCategoriesAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _apiService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteBookAsync(id);
                TempData["SuccessMessage"] = "Book deleted successfully!";
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error deleting book with ID {BookId}", id);
                TempData["ErrorMessage"] = "An error occurred while deleting the book.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}