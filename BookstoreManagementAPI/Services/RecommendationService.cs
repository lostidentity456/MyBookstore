using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<RecommendationService> _logger;

        public RecommendationService(BookstoreDbContext context, ILogger<RecommendationService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<BookDto>> GetRecommendationsForUserAsync(int userId, int count = 10)
        {
            try
            {
                // Get user's purchase history
                var userOrders = await _context.Orders
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Book)
                    .Where(o => o.UserId == userId && o.Status == OrderStatus.Delivered)
                    .ToListAsync();

                var purchasedBookIds = userOrders
                    .SelectMany(o => o.OrderItems)
                    .Select(oi => oi.BookId)
                    .Distinct()
                    .ToList();

                // Get user's favorite categories and authors
                var favoriteCategories = userOrders
                    .SelectMany(o => o.OrderItems)
                    .Select(oi => oi.Book.CategoryId)
                    .GroupBy(c => c)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .Take(3)
                    .ToList();

                var favoriteAuthors = userOrders
                    .SelectMany(o => o.OrderItems)
                    .Select(oi => oi.Book.AuthorId)
                    .GroupBy(a => a)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .Take(3)
                    .ToList();

                // Get recommendations based on different strategies
                var recommendations = new List<BookDto>();

                // 1. Books from favorite categories
                if (favoriteCategories.Any())
                {
                    var categoryBooks = await GetBooksByCategoriesAsync(favoriteCategories, purchasedBookIds, count / 3);
                    recommendations.AddRange(categoryBooks);
                }

                // 2. Books from favorite authors
                if (favoriteAuthors.Any())
                {
                    var authorBooks = await GetBooksByAuthorsAsync(favoriteAuthors, purchasedBookIds, count / 3);
                    recommendations.AddRange(authorBooks);
                }

                // 3. Trending books
                var trendingBooks = await GetTrendingBooksAsync(count / 3);
                recommendations.AddRange(trendingBooks);

                // Remove duplicates and return top recommendations
                return recommendations
                    .GroupBy(b => b.Id)
                    .Select(g => g.First())
                    .Take(count)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting recommendations for user {UserId}", userId);
                return new List<BookDto>();
            }
        }

        public async Task<IEnumerable<BookDto>> GetSimilarBooksAsync(int bookId, int count = 5)
        {
            try
            {
                var book = await _context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(b => b.Id == bookId);

                if (book == null)
                {
                    return new List<BookDto>();
                }

                // Get similar books from same category and author
                var similarBooks = await _context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Author)
                    .Where(b => b.Id != bookId && b.IsActive && 
                        (b.CategoryId == book.CategoryId || b.AuthorId == book.AuthorId))
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
                    .Take(count)
                    .ToListAsync();

                return similarBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting similar books for book {BookId}", bookId);
                return new List<BookDto>();
            }
        }

        public async Task<IEnumerable<BookDto>> GetTrendingBooksAsync(int count = 10)
        {
            try
            {
                // Get books with most orders in the last 30 days
                var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);

                var trendingBooks = await _context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Author)
                    .Include(b => b.OrderItems)
                        .ThenInclude(oi => oi.Order)
                    .Where(b => b.IsActive)
                    .Select(b => new
                    {
                        Book = b,
                        OrderCount = b.OrderItems
                            .Where(oi => oi.Order.CreatedAt >= thirtyDaysAgo)
                            .Sum(oi => oi.Quantity)
                    })
                    .OrderByDescending(x => x.OrderCount)
                    .ThenByDescending(x => x.Book.AverageRating)
                    .Take(count)
                    .Select(x => new BookDto
                    {
                        Id = x.Book.Id,
                        Title = x.Book.Title,
                        Description = x.Book.Description,
                        ISBN = x.Book.ISBN,
                        Publisher = x.Book.Publisher,
                        PublicationDate = x.Book.PublicationDate,
                        Language = x.Book.Language,
                        NumberOfPages = x.Book.NumberOfPages,
                        Edition = x.Book.Edition,
                        ImageUrl = x.Book.ImageUrl,
                        Price = x.Book.Price,
                        DiscountPrice = x.Book.DiscountPrice,
                        CurrentPrice = x.Book.CurrentPrice,
                        StockQuantity = x.Book.StockQuantity,
                        IsInStock = x.Book.IsInStock,
                        IsLowStock = x.Book.IsLowStock,
                        IsActive = x.Book.IsActive,
                        IsFeatured = x.Book.IsFeatured,
                        AverageRating = x.Book.AverageRating,
                        TotalReviews = x.Book.TotalReviews,
                        CreatedAt = x.Book.CreatedAt,
                        UpdatedAt = x.Book.UpdatedAt,
                        CategoryId = x.Book.CategoryId,
                        AuthorId = x.Book.AuthorId,
                        CategoryName = x.Book.Category.Name,
                        AuthorName = x.Book.Author.FullName
                    })
                    .ToListAsync();

                return trendingBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting trending books");
                return new List<BookDto>();
            }
        }

        public async Task<IEnumerable<BookDto>> GetNewReleasesAsync(int count = 10)
        {
            try
            {
                var sixMonthsAgo = DateTime.UtcNow.AddMonths(-6);

                var newReleases = await _context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Author)
                    .Where(b => b.IsActive && b.PublicationDate >= sixMonthsAgo)
                    .OrderByDescending(b => b.PublicationDate)
                    .ThenByDescending(b => b.AverageRating)
                    .Take(count)
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

                return newReleases;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting new releases");
                return new List<BookDto>();
            }
        }

        public async Task UpdateRecommendationsForUserAsync(int userId)
        {
            try
            {
                // Remove existing recommendations for user
                var existingRecommendations = await _context.Recommendations
                    .Where(r => r.UserId == userId)
                    .ToListAsync();

                _context.Recommendations.RemoveRange(existingRecommendations);

                // Generate new recommendations
                var recommendations = await GetRecommendationsForUserAsync(userId, 20);
                var newRecommendations = recommendations.Select((book, index) => new Recommendation
                {
                    UserId = userId,
                    BookId = book.Id,
                    Type = RecommendationType.BasedOnPurchaseHistory,
                    Score = 1.0 - (index * 0.1), // Decreasing score
                    Reason = "Based on your purchase history",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });

                _context.Recommendations.AddRange(newRecommendations);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating recommendations for user {UserId}", userId);
            }
        }

        public async Task UpdateAllRecommendationsAsync()
        {
            try
            {
                var userIds = await _context.Users
                    .Where(u => u.IsActive)
                    .Select(u => u.Id)
                    .ToListAsync();

                foreach (var userId in userIds)
                {
                    await UpdateRecommendationsForUserAsync(userId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating all recommendations");
            }
        }

        private async Task<List<BookDto>> GetBooksByCategoriesAsync(List<int> categoryIds, List<int> excludeBookIds, int count)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.IsActive && categoryIds.Contains(b.CategoryId) && !excludeBookIds.Contains(b.Id))
                .OrderByDescending(b => b.AverageRating)
                .Take(count)
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
        }

        private async Task<List<BookDto>> GetBooksByAuthorsAsync(List<int> authorIds, List<int> excludeBookIds, int count)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.IsActive && authorIds.Contains(b.AuthorId) && !excludeBookIds.Contains(b.Id))
                .OrderByDescending(b => b.AverageRating)
                .Take(count)
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
        }
    }
}
