using OnlineBookstoreManagement.Models;

namespace OnlineBookstoreManagement.Services
{
    public interface IApiService
    {
        Task<List<BookViewModel>> GetBooksAsync();
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task<BookViewModel> CreateBookAsync(BookViewModel book);
        Task UpdateBookAsync(int id, BookViewModel book);
        Task DeleteBookAsync(int id);
        Task<List<BookViewModel>> SearchBooksAsync(string searchTerm);
        Task<List<BookViewModel>> GetBooksByCategoryAsync(int categoryId);
        Task<List<BookViewModel>> GetBooksByAuthorAsync(int authorId);
        Task<List<BookViewModel>> GetFeaturedBooksAsync();
        Task<StatisticsDto> GetDashboardStatisticsAsync();
        Task<List<CategoryViewModel>> GetCategoriesAsync();
        Task<List<AuthorViewModel>> GetAuthorsAsync();
        Task<AuthorViewModel?> GetAuthorByIdAsync(int id);
        Task<bool> CreateAuthorAsync(AuthorViewModel author);
        Task<bool> UpdateAuthorAsync(AuthorViewModel author);
        Task<bool> DeleteAuthorAsync(int id);
        Task<List<OrderViewModel>> GetOrdersAsync();
        Task<OrderViewModel?> GetOrderByIdAsync(int id);
        Task<OrderViewModel> CreateOrderAsync(CreateOrderViewModel order);
        Task<List<OrderViewModel>> GetAllOrdersAsync();
        Task<OrderViewModel?> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto dto);
        Task<bool> CancelOrderAsync(int id);
        Task<CategoryViewModel?> GetCategoryByIdAsync(int id);
        Task<bool> CreateCategoryAsync(CategoryViewModel category);
        Task<bool> UpdateCategoryAsync(CategoryViewModel category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<(List<BookViewModel> Items, int TotalPages, int TotalItems)> GetBooksPagedAsync(int page, int pageSize, string? sort);
        Task<PaymentDto?> CreatePaymentAsync(CreatePaymentDto dto);
        Task<PaymentDto?> ProcessPaymentAsync(ProcessPaymentDto dto);
        Task<string> LoginAsync(string email, string password);
        Task<(bool Success, string ErrorMessage)> RegisterAsync(string firstName, string lastName, string email, string password);
        Task<bool> IsAuthenticatedAsync();
        string? GetToken();
        void SetToken(string token);
        void ClearToken();
    }
}
