using OnlineBookstoreManagementAPI.DTOs;

namespace OnlineBookstoreManagementAPI.Services
{
    public interface IRecommendationService
    {
        Task<IEnumerable<BookDto>> GetRecommendationsForUserAsync(int userId, int count = 10);
        Task<IEnumerable<BookDto>> GetSimilarBooksAsync(int bookId, int count = 5);
        Task<IEnumerable<BookDto>> GetTrendingBooksAsync(int count = 10);
        Task<IEnumerable<BookDto>> GetNewReleasesAsync(int count = 10);
        Task UpdateRecommendationsForUserAsync(int userId);
        Task UpdateAllRecommendationsAsync();
    }
}
