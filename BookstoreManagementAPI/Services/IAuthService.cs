using OnlineBookstoreManagementAPI.DTOs;

namespace OnlineBookstoreManagementAPI.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(CreateUserDto createUserDto);
        bool ValidateToken(string token);
        Task<UserDto?> GetUserFromTokenAsync(string token);
    }
}
