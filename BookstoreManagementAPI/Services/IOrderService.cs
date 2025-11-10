using OnlineBookstoreManagementAPI.DTOs;

namespace OnlineBookstoreManagementAPI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto createOrderDto);
        Task<OrderDto?> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto updateOrderStatusDto);
        Task<bool> CancelOrderAsync(int id);
        Task<decimal> CalculateOrderTotalAsync(CreateOrderDto createOrderDto);
    }
}
