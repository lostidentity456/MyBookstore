using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;

namespace OnlineBookstoreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorsAdminController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<AuthorsAdminController> _logger;

        public AuthorsAdminController(IApiService apiService, ILogger<AuthorsAdminController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _apiService.GetAuthorsAsync();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View(new AuthorViewModel { IsActive = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var ok = await _apiService.CreateAuthorAsync(model);
            if (!ok)
            {
                TempData["ErrorMessage"] = "Failed to create author.";
                return View(model);
            }
            TempData["SuccessMessage"] = "Author created.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _apiService.GetAuthorByIdAsync(id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AuthorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var ok = await _apiService.UpdateAuthorAsync(model);
            if (!ok)
            {
                TempData["ErrorMessage"] = "Failed to update author.";
                return View(model);
            }
            TempData["SuccessMessage"] = "Author updated.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _apiService.DeleteAuthorAsync(id);
            TempData[ok ? "SuccessMessage" : "ErrorMessage"] = ok ? "Author deleted." : "Failed to delete author.";
            return RedirectToAction(nameof(Index));
        }
    }
}


