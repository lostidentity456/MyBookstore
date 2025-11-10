using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<BookService> _logger;

        public BookService(BookstoreDbContext context, ILogger<BookService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.IsActive)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    PublicationDate = b.PublicationDate,
                    Language = b.Language,
                    NumberOfPages = b.NumberOfPages,
                    Edition = b.Edition,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    DiscountPrice = b.DiscountPrice,
                    CurrentPrice = b.CurrentPrice,
                    StockQuantity = b.StockQuantity,
                    IsInStock = b.IsInStock,
                    IsLowStock = b.IsLowStock,
                    IsActive = b.IsActive,
                    IsFeatured = b.IsFeatured,
                    AverageRating = b.AverageRating,
                    TotalReviews = b.TotalReviews,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    CategoryId = b.CategoryId,
                    AuthorId = b.AuthorId,
                    CategoryName = b.Category.Name,
                    AuthorName = b.Author.FullName
                })
                .ToListAsync();

            return books;
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.Id == id && b.IsActive)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    PublicationDate = b.PublicationDate,
                    Language = b.Language,
                    NumberOfPages = b.NumberOfPages,
                    Edition = b.Edition,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    DiscountPrice = b.DiscountPrice,
                    CurrentPrice = b.CurrentPrice,
                    StockQuantity = b.StockQuantity,
                    IsInStock = b.IsInStock,
                    IsLowStock = b.IsLowStock,
                    IsActive = b.IsActive,
                    IsFeatured = b.IsFeatured,
                    AverageRating = b.AverageRating,
                    TotalReviews = b.TotalReviews,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    CategoryId = b.CategoryId,
                    AuthorId = b.AuthorId,
                    CategoryName = b.Category.Name,
                    AuthorName = b.Author.FullName
                })
                .FirstOrDefaultAsync();

            return book;
        }

        public async Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId)
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.CategoryId == categoryId && b.IsActive)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    PublicationDate = b.PublicationDate,
                    Language = b.Language,
                    NumberOfPages = b.NumberOfPages,
                    Edition = b.Edition,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    DiscountPrice = b.DiscountPrice,
                    CurrentPrice = b.CurrentPrice,
                    StockQuantity = b.StockQuantity,
                    IsInStock = b.IsInStock,
                    IsLowStock = b.IsLowStock,
                    IsActive = b.IsActive,
                    IsFeatured = b.IsFeatured,
                    AverageRating = b.AverageRating,
                    TotalReviews = b.TotalReviews,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    CategoryId = b.CategoryId,
                    AuthorId = b.AuthorId,
                    CategoryName = b.Category.Name,
                    AuthorName = b.Author.FullName
                })
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorId)
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.AuthorId == authorId && b.IsActive)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    PublicationDate = b.PublicationDate,
                    Language = b.Language,
                    NumberOfPages = b.NumberOfPages,
                    Edition = b.Edition,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    DiscountPrice = b.DiscountPrice,
                    CurrentPrice = b.CurrentPrice,
                    StockQuantity = b.StockQuantity,
                    IsInStock = b.IsInStock,
                    IsLowStock = b.IsLowStock,
                    IsActive = b.IsActive,
                    IsFeatured = b.IsFeatured,
                    AverageRating = b.AverageRating,
                    TotalReviews = b.TotalReviews,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    CategoryId = b.CategoryId,
                    AuthorId = b.AuthorId,
                    CategoryName = b.Category.Name,
                    AuthorName = b.Author.FullName
                })
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<BookDto>> SearchBooksAsync(string searchTerm)
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.IsActive && 
                    (b.Title.Contains(searchTerm) || 
                     b.Description!.Contains(searchTerm) ||
                     b.Author.FirstName.Contains(searchTerm) ||
                     b.Author.LastName.Contains(searchTerm) ||
                     b.Category.Name.Contains(searchTerm)))
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    PublicationDate = b.PublicationDate,
                    Language = b.Language,
                    NumberOfPages = b.NumberOfPages,
                    Edition = b.Edition,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    DiscountPrice = b.DiscountPrice,
                    CurrentPrice = b.CurrentPrice,
                    StockQuantity = b.StockQuantity,
                    IsInStock = b.IsInStock,
                    IsLowStock = b.IsLowStock,
                    IsActive = b.IsActive,
                    IsFeatured = b.IsFeatured,
                    AverageRating = b.AverageRating,
                    TotalReviews = b.TotalReviews,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    CategoryId = b.CategoryId,
                    AuthorId = b.AuthorId,
                    CategoryName = b.Category.Name,
                    AuthorName = b.Author.FullName
                })
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<BookDto>> GetFeaturedBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.IsActive && b.IsFeatured)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    PublicationDate = b.PublicationDate,
                    Language = b.Language,
                    NumberOfPages = b.NumberOfPages,
                    Edition = b.Edition,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    DiscountPrice = b.DiscountPrice,
                    CurrentPrice = b.CurrentPrice,
                    StockQuantity = b.StockQuantity,
                    IsInStock = b.IsInStock,
                    IsLowStock = b.IsLowStock,
                    IsActive = b.IsActive,
                    IsFeatured = b.IsFeatured,
                    AverageRating = b.AverageRating,
                    TotalReviews = b.TotalReviews,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    CategoryId = b.CategoryId,
                    AuthorId = b.AuthorId,
                    CategoryName = b.Category.Name,
                    AuthorName = b.Author.FullName
                })
                .ToListAsync();

            return books;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Title = createBookDto.Title,
                Description = createBookDto.Description,
                ISBN = createBookDto.ISBN,
                Publisher = createBookDto.Publisher,
                PublicationDate = createBookDto.PublicationDate,
                Language = createBookDto.Language,
                NumberOfPages = createBookDto.NumberOfPages,
                Edition = createBookDto.Edition,
                ImageUrl = createBookDto.ImageUrl,
                Price = createBookDto.Price,
                DiscountPrice = createBookDto.DiscountPrice,
                StockQuantity = createBookDto.StockQuantity,
                MinStockLevel = createBookDto.MinStockLevel,
                IsActive = createBookDto.IsActive,
                IsFeatured = createBookDto.IsFeatured,
                CategoryId = createBookDto.CategoryId,
                AuthorId = createBookDto.AuthorId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return await GetBookByIdAsync(book.Id) ?? throw new InvalidOperationException("Failed to retrieve created book");
        }

        public async Task<BookDto?> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            book.Title = updateBookDto.Title;
            book.Description = updateBookDto.Description;
            book.ISBN = updateBookDto.ISBN;
            book.Publisher = updateBookDto.Publisher;
            book.PublicationDate = updateBookDto.PublicationDate;
            book.Language = updateBookDto.Language;
            book.NumberOfPages = updateBookDto.NumberOfPages;
            book.Edition = updateBookDto.Edition;
            book.ImageUrl = updateBookDto.ImageUrl;
            book.Price = updateBookDto.Price;
            book.DiscountPrice = updateBookDto.DiscountPrice;
            book.StockQuantity = updateBookDto.StockQuantity;
            book.MinStockLevel = updateBookDto.MinStockLevel;
            book.IsActive = updateBookDto.IsActive;
            book.IsFeatured = updateBookDto.IsFeatured;
            book.CategoryId = updateBookDto.CategoryId;
            book.AuthorId = updateBookDto.AuthorId;
            book.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await GetBookByIdAsync(book.Id);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            book.IsActive = false;
            book.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStockAsync(int bookId, int quantity)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return false;

            book.StockQuantity = quantity;
            book.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
