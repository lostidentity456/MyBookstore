using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;

namespace OnlineBookstoreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesAdminController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<CategoriesAdminController> _logger;

        public CategoriesAdminController(IApiService apiService, ILogger<CategoriesAdminController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _apiService.GetCategoriesAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(new CategoryViewModel { IsActive = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var ok = await _apiService.CreateCategoryAsync(model);
            if (!ok)
            {
                TempData["ErrorMessage"] = "Failed to create category.";
                return View(model);
            }
            TempData["SuccessMessage"] = "Category created.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _apiService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var ok = await _apiService.UpdateCategoryAsync(model);
            if (!ok)
            {
                TempData["ErrorMessage"] = "Failed to update category.";
                return View(model);
            }
            TempData["SuccessMessage"] = "Category updated.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _apiService.DeleteCategoryAsync(id);
            TempData[ok ? "SuccessMessage" : "ErrorMessage"] = ok ? "Category deleted." : "Failed to delete category.";
            return RedirectToAction(nameof(Index));
        }
    }
}


