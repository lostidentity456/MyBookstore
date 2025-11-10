using OnlineBookstoreManagement.Models;

namespace OnlineBookstoreManagement.Services
{
    public interface IApiService
    {
        Task<List<BookViewModel>> GetBooksAsync();
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task<List<BookViewModel>> SearchBooksAsync(string searchTerm);
        Task<List<BookViewModel>> GetBooksByCategoryAsync(int categoryId);
        Task<List<BookViewModel>> GetBooksByAuthorAsync(int authorId);
        Task<List<BookViewModel>> GetFeaturedBooksAsync();
        Task<List<CategoryViewModel>> GetCategoriesAsync();
        Task<List<AuthorViewModel>> GetAuthorsAsync();
        Task<List<OrderViewModel>> GetOrdersAsync();
        Task<OrderViewModel?> GetOrderByIdAsync(int id);
        Task<OrderViewModel> CreateOrderAsync(CreateOrderViewModel order);
        Task<string> LoginAsync(string email, string password);
        Task<(bool Success, string ErrorMessage)> RegisterAsync(string firstName, string lastName, string email, string password);
        Task<bool> IsAuthenticatedAsync();
        string? GetToken();
        void SetToken(string token);
        void ClearToken();
    }
}
