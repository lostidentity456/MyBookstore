using System.Text;
using System.Text.Json;
using OnlineBookstoreManagement.Models;

namespace OnlineBookstoreManagement.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            
            _httpClient.BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"]!);
        }

        public async Task<List<BookViewModel>> GetBooksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/books");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return books ?? new List<BookViewModel>();
                }
                return new List<BookViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books");
                return new List<BookViewModel>();
            }
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/books/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var book = JsonSerializer.Deserialize<BookViewModel>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return book;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving book with ID {BookId}", id);
                return null;
            }
        }

        public async Task<List<BookViewModel>> SearchBooksAsync(string searchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/books/search?q={Uri.EscapeDataString(searchTerm)}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return books ?? new List<BookViewModel>();
                }
                return new List<BookViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching books with term {SearchTerm}", searchTerm);
                return new List<BookViewModel>();
            }
        }

        public async Task<List<BookViewModel>> GetBooksByCategoryAsync(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/books/category/{categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return books ?? new List<BookViewModel>();
                }
                return new List<BookViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books for category {CategoryId}", categoryId);
                return new List<BookViewModel>();
            }
        }

        public async Task<List<BookViewModel>> GetBooksByAuthorAsync(int authorId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/books/author/{authorId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return books ?? new List<BookViewModel>();
                }
                return new List<BookViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books for author {AuthorId}", authorId);
                return new List<BookViewModel>();
            }
        }

        public async Task<List<BookViewModel>> GetFeaturedBooksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/books/featured");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return books ?? new List<BookViewModel>();
                }
                return new List<BookViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving featured books");
                return new List<BookViewModel>();
            }
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/categories");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return categories ?? new List<CategoryViewModel>();
                }
                return new List<CategoryViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving categories");
                return new List<CategoryViewModel>();
            }
        }

        public async Task<List<AuthorViewModel>> GetAuthorsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/authors");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var authors = JsonSerializer.Deserialize<List<AuthorViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return authors ?? new List<AuthorViewModel>();
                }
                return new List<AuthorViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving authors");
                return new List<AuthorViewModel>();
            }
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync()
        {
            try
            {
                var token = GetToken();
                if (string.IsNullOrEmpty(token))
                {
                    return new List<OrderViewModel>();
                }

                SetAuthorizationHeader(token);
                var response = await _httpClient.GetAsync("/api/orders/my-orders");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var orders = JsonSerializer.Deserialize<List<OrderViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return orders ?? new List<OrderViewModel>();
                }
                return new List<OrderViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders");
                return new List<OrderViewModel>();
            }
            finally
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        public async Task<OrderViewModel?> GetOrderByIdAsync(int id)
        {
            try
            {
                var token = GetToken();
                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync($"/api/orders/{id}");
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var order = JsonSerializer.Deserialize<OrderViewModel>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return order;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order with ID {OrderId}", id);
                return null;
            }
        }

        public async Task<OrderViewModel> CreateOrderAsync(CreateOrderViewModel order)
        {
            try
            {
                var token = GetToken();
                if (string.IsNullOrEmpty(token))
                {
                    throw new UnauthorizedAccessException("User not authenticated");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                
                var json = JsonSerializer.Serialize(order);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("/api/orders", content);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var createdOrder = JsonSerializer.Deserialize<OrderViewModel>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return createdOrder ?? throw new InvalidOperationException("Failed to create order");
                }
                
                throw new HttpRequestException($"Failed to create order: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                throw;
            }
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            try
            {
                var loginData = new { email, password };
                var json = JsonSerializer.Serialize(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("/api/auth/login", content);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<JsonElement>(responseContent);
                    
                    if (result.TryGetProperty("token", out var tokenElement))
                    {
                        var token = tokenElement.GetString();
                        if (!string.IsNullOrEmpty(token))
                        {
                            SetToken(token);
                            return token;
                        }
                    }
                }
                
                throw new UnauthorizedAccessException("Invalid email or password");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for email {Email}", email);
                throw;
            }
        }

        public async Task<(bool Success, string ErrorMessage)> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            try
            {
                var registerData = new { firstName, lastName, email, password };
                var json = JsonSerializer.Serialize(registerData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return (false, errorContent); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for email {Email}", email);
                return (false, "An unexpected network error occurred. Please try again.");
            }
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            try
            {
                var tokenData = new { token };
                var json = JsonSerializer.Serialize(tokenData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("/api/auth/validate", content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private void SetAuthorizationHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        public string? GetToken()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
        }

        public void SetToken(string token)
        {
            _httpContextAccessor.HttpContext?.Session.SetString("AuthToken", token);
        }

        public void ClearToken()
        {
            _httpContextAccessor.HttpContext?.Session.Remove("AuthToken");
        }
    }
}
