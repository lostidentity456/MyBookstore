using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBookstoreManagement.Models;
using OnlineBookstoreManagement.Services;

namespace OnlineBookstoreManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IApiService apiService, ILogger<HomeController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var featuredBooks = await _apiService.GetFeaturedBooksAsync();
                var categories = await _apiService.GetCategoriesAsync();
                
                var model = new BookListViewModel
                {
                    Books = featuredBooks,
                    Categories = categories
                };


                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading home page");
                return View(new BookListViewModel());
            }
        }

        public async Task<IActionResult> Books(string? search, int? categoryId, int? authorId, int page = 1, string? sort = null)
        {
            try
            {
                var categories = await _apiService.GetCategoriesAsync();
                var authors = await _apiService.GetAuthorsAsync();

                BookListViewModel model;

                if (!string.IsNullOrEmpty(search))
                {
                    var books = await _apiService.SearchBooksAsync(search);
                    model = new BookListViewModel
                    {
                        Books = books,
                        TotalPages = 1, 
                        CurrentPage = 1
                    };
                }
                else if (categoryId.HasValue)
                {
                    var books = await _apiService.GetBooksByCategoryAsync(categoryId.Value);
                    model = new BookListViewModel
                    {
                        Books = books,
                        TotalPages = 1,
                        CurrentPage = 1
                    };
                }
                else if (authorId.HasValue)
                {
                    var books = await _apiService.GetBooksByAuthorAsync(authorId.Value);
                    model = new BookListViewModel
                    {
                        Books = books,
                        TotalPages = 1,
                        CurrentPage = 1
                    };
                }
                else
                {
                    var pagedResult = await _apiService.GetBooksPagedAsync(page, 12, sort);
                    model = new BookListViewModel
                    {
                        Books = pagedResult.Items,
                        TotalPages = pagedResult.TotalPages
                    };
                }

                model.Categories = categories;
                model.Authors = authors;
                model.SearchTerm = search;
                model.CategoryId = categoryId;
                model.AuthorId = authorId;
                model.PageSize = 12;
                model.CategoryList = new SelectList(categories, "Id", "Name", model.CategoryId);
                model.AuthorList = new SelectList(authors, "Id", "FullName", model.AuthorId);
                ViewBag.Sort = sort;

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading books page");
                return View(new BookListViewModel()); 
            }
        }

        public async Task<IActionResult> BookDetails(int id)
        {
            try
            {
                var book = await _apiService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading book details for ID {BookId}", id);
                return NotFound();
            }
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
