using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Services;

namespace OnlineBookstoreManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books");
                return StatusCode(500, "An error occurred while retrieving books");
            }
        }

        /// <summary>
        /// Get a book by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving book with ID {BookId}", id);
                return StatusCode(500, "An error occurred while retrieving the book");
            }
        }

        /// <summary>
        /// Get books by category
        /// </summary>
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByCategory(int categoryId)
        {
            try
            {
                var books = await _bookService.GetBooksByCategoryAsync(categoryId);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books for category {CategoryId}", categoryId);
                return StatusCode(500, "An error occurred while retrieving books");
            }
        }

        /// <summary>
        /// Get books by author
        /// </summary>
        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthor(int authorId)
        {
            try
            {
                var books = await _bookService.GetBooksByAuthorAsync(authorId);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books for author {AuthorId}", authorId);
                return StatusCode(500, "An error occurred while retrieving books");
            }
        }

        /// <summary>
        /// Search books
        /// </summary>
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks([FromQuery] string q)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(q))
                {
                    return BadRequest("Search query cannot be empty");
                }

                var books = await _bookService.SearchBooksAsync(q);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching books with query {Query}", q);
                return StatusCode(500, "An error occurred while searching books");
            }
        }

        /// <summary>
        /// Get featured books
        /// </summary>
        [HttpGet("featured")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetFeaturedBooks()
        {
            try
            {
                var books = await _bookService.GetFeaturedBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving featured books");
                return StatusCode(500, "An error occurred while retrieving featured books");
            }
        }

        /// <summary>
        /// Create a new book (Admin/Store Owner only)
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto createBookDto)
        {
            try
            {
                var book = await _bookService.CreateBookAsync(createBookDto);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating book");
                return StatusCode(500, "An error occurred while creating the book");
            }
        }

        /// <summary>
        /// Update a book (Admin/Store Owner only)
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, UpdateBookDto updateBookDto)
        {
            try
            {
                var book = await _bookService.UpdateBookAsync(id, updateBookDto);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating book with ID {BookId}", id);
                return StatusCode(500, "An error occurred while updating the book");
            }
        }

        /// <summary>
        /// Delete a book (Admin/Store Owner only)
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var result = await _bookService.DeleteBookAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting book with ID {BookId}", id);
                return StatusCode(500, "An error occurred while deleting the book");
            }
        }

        /// <summary>
        /// Update book stock (Admin/Store Owner only)
        /// </summary>
        [HttpPut("{id}/stock")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] int quantity)
        {
            try
            {
                var result = await _bookService.UpdateStockAsync(id, quantity);
                if (!result)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating stock for book with ID {BookId}", id);
                return StatusCode(500, "An error occurred while updating stock");
            }
        }
    }
}
