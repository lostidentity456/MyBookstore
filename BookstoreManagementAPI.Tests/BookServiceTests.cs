using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Models;
using OnlineBookstoreManagementAPI.Services;

namespace OnlineBookstoreManagementAPI.Tests
{
    public class BookServiceTests
    {
        private readonly BookstoreDbContext _context;
        private readonly BookService _bookService;
        private readonly Mock<ILogger<BookService>> _mockLogger;

        public BookServiceTests()
        {
            var options = new DbContextOptionsBuilder<BookstoreDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new BookstoreDbContext(options);
            _mockLogger = new Mock<ILogger<BookService>>();
            _bookService = new BookService(_context, _mockLogger.Object);

            SeedTestData();
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnAllActiveBooks()
        {
            // Act
            var result = await _bookService.GetAllBooksAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetBookByIdAsync_WithValidId_ShouldReturnBook()
        {
            // Act
            var result = await _bookService.GetBookByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Book 1", result.Title);
        }

        [Fact]
        public async Task GetBookByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Act
            var result = await _bookService.GetBookByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateBookAsync_WithValidData_ShouldCreateBook()
        {
            // Arrange
            var createBookDto = new CreateBookDto
            {
                Title = "New Test Book",
                ISBN = "978-1234567890",
                Publisher = "Test Publisher",
                PublicationDate = DateTime.UtcNow,
                Language = "English",
                NumberOfPages = 200,
                Price = 19.99m,
                StockQuantity = 10,
                CategoryId = 1,
                AuthorId = 1
            };

            // Act
            var result = await _bookService.CreateBookAsync(createBookDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Test Book", result.Title);
            Assert.Equal(3, result.Id);
        }

        [Fact]
        public async Task SearchBooksAsync_WithValidTerm_ShouldReturnMatchingBooks()
        {
            // Act
            var result = await _bookService.SearchBooksAsync("Test Book 1");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Test Book 1", result.First().Title);
        }

        [Fact]
        public async Task UpdateStockAsync_WithValidData_ShouldUpdateStock()
        {
            // Act
            var result = await _bookService.UpdateStockAsync(1, 50);

            // Assert
            Assert.True(result);
            var book = await _context.Books.FindAsync(1);
            Assert.Equal(50, book?.StockQuantity);
        }

        private void SeedTestData()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Fiction", IsActive = true },
                new Category { Id = 2, Name = "Non-Fiction", IsActive = true }
            };

            var authors = new List<Author>
            {
                new Author { Id = 1, FirstName = "Test", LastName = "Author", IsActive = true },
                new Author { Id = 2, FirstName = "Another", LastName = "Author", IsActive = true }
            };

            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Test Book 1",
                    ISBN = "978-1111111111",
                    Publisher = "Test Publisher",
                    PublicationDate = DateTime.UtcNow,
                    Language = "English",
                    NumberOfPages = 200,
                    Price = 19.99m,
                    StockQuantity = 10,
                    CategoryId = 1,
                    AuthorId = 1,
                    IsActive = true
                },
                new Book
                {
                    Id = 2,
                    Title = "Test Book 2",
                    ISBN = "978-2222222222",
                    Publisher = "Test Publisher",
                    PublicationDate = DateTime.UtcNow,
                    Language = "English",
                    NumberOfPages = 300,
                    Price = 29.99m,
                    StockQuantity = 5,
                    CategoryId = 2,
                    AuthorId = 2,
                    IsActive = true
                }
            };

            _context.Categories.AddRange(categories);
            _context.Authors.AddRange(authors);
            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
