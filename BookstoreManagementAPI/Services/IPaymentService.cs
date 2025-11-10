using OnlineBookstoreManagementAPI.DTOs;

namespace OnlineBookstoreManagementAPI.Services
{
    public interface IPaymentService
    {
        Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<PaymentDto?> GetPaymentByIdAsync(int id);
        Task<IEnumerable<PaymentDto>> GetPaymentsByOrderIdAsync(int orderId);
        Task<PaymentDto> ProcessPaymentAsync(ProcessPaymentDto processPaymentDto);
        Task<PaymentDto> RefundPaymentAsync(int paymentId, decimal? amount = null);
        Task<bool> ValidatePaymentAsync(int paymentId);
        Task<decimal> CalculateRefundAmountAsync(int paymentId);
    }
}
