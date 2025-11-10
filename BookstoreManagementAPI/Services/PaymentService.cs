using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(BookstoreDbContext context, ILogger<PaymentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            // Validate order exists and is in correct status
            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == createPaymentDto.OrderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found");
            }

            if (order.Status != OrderStatus.Pending && order.Status != OrderStatus.Confirmed)
            {
                throw new InvalidOperationException("Order is not in a valid state for payment");
            }

            var payment = new Payment
            {
                OrderId = createPaymentDto.OrderId,
                PaymentMethod = createPaymentDto.PaymentMethod,
                Amount = createPaymentDto.Amount,
                Currency = createPaymentDto.Currency ?? "USD",
                Notes = createPaymentDto.Notes,
                PaymentDetails = createPaymentDto.PaymentDetails != null 
                    ? System.Text.Json.JsonSerializer.Serialize(createPaymentDto.PaymentDetails)
                    : null,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return await GetPaymentByIdAsync(payment.Id) ?? throw new InvalidOperationException("Failed to retrieve created payment");
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Order)
                .Where(p => p.Id == id)
                .Select(p => new PaymentDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    PaymentMethod = p.PaymentMethod,
                    TransactionId = p.TransactionId,
                    Amount = p.Amount,
                    Status = p.Status,
                    Currency = p.Currency,
                    Notes = p.Notes,
                    PaymentDetails = p.PaymentDetails,
                    CreatedAt = p.CreatedAt,
                    ProcessedAt = p.ProcessedAt,
                    UpdatedAt = p.UpdatedAt,
                    OrderNumber = p.Order.OrderNumber
                })
                .FirstOrDefaultAsync();

            return payment;
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByOrderIdAsync(int orderId)
        {
            var payments = await _context.Payments
                .Include(p => p.Order)
                .Where(p => p.OrderId == orderId)
                .Select(p => new PaymentDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    PaymentMethod = p.PaymentMethod,
                    TransactionId = p.TransactionId,
                    Amount = p.Amount,
                    Status = p.Status,
                    Currency = p.Currency,
                    Notes = p.Notes,
                    PaymentDetails = p.PaymentDetails,
                    CreatedAt = p.CreatedAt,
                    ProcessedAt = p.ProcessedAt,
                    UpdatedAt = p.UpdatedAt,
                    OrderNumber = p.Order.OrderNumber
                })
                .ToListAsync();

            return payments;
        }

        public async Task<PaymentDto> ProcessPaymentAsync(ProcessPaymentDto processPaymentDto)
        {
            var payment = await _context.Payments.FindAsync(processPaymentDto.PaymentId);
            if (payment == null)
            {
                throw new InvalidOperationException("Payment not found");
            }

            // Simulate payment processing
            payment.TransactionId = processPaymentDto.TransactionId ?? GenerateTransactionId();
            payment.Status = processPaymentDto.Status;
            payment.Notes = processPaymentDto.Notes;
            payment.ProcessedAt = DateTime.UtcNow;
            payment.UpdatedAt = DateTime.UtcNow;

            // Update order status based on payment status
            var order = await _context.Orders.FindAsync(payment.OrderId);
            if (order != null)
            {
                switch (processPaymentDto.Status)
                {
                    case PaymentStatus.Completed:
                        order.PaymentStatus = OrderPaymentStatus.Paid;
                        order.Status = OrderStatus.Confirmed;
                        order.TransactionId = payment.TransactionId;
                        break;
                    case PaymentStatus.Failed:
                        order.PaymentStatus = OrderPaymentStatus.Failed;
                        break;
                    case PaymentStatus.Cancelled:
                        order.PaymentStatus = OrderPaymentStatus.Pending;
                        break;
                }
                order.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            return await GetPaymentByIdAsync(payment.Id) ?? throw new InvalidOperationException("Failed to retrieve updated payment");
        }

        public async Task<PaymentDto> RefundPaymentAsync(int paymentId, decimal? amount = null)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null)
            {
                throw new InvalidOperationException("Payment not found");
            }

            if (payment.Status != PaymentStatus.Completed && payment.Status != PaymentStatus.PartiallyRefunded)
            {
                throw new InvalidOperationException("Only completed or partially refunded payments can be refunded");
            }

            var maxRefundableAmount = await CalculateRefundAmountAsync(paymentId);
            var refundAmount = amount ?? maxRefundableAmount; 

            if (refundAmount <= 0)
            {
                throw new InvalidOperationException("Refund amount must be greater than zero.");
            }

            if (refundAmount > maxRefundableAmount)
            {
                throw new InvalidOperationException($"Refund amount cannot exceed the remaining refundable amount of {maxRefundableAmount:C}");
            }

            var refund = new Payment
            {
                OrderId = payment.OrderId,
                PaymentMethod = payment.PaymentMethod,
                Amount = -refundAmount, 
                Currency = payment.Currency,
                Status = PaymentStatus.Refunded,
                TransactionId = GenerateTransactionId(),
                Notes = $"Refund for original transaction {payment.TransactionId}",
                CreatedAt = DateTime.UtcNow,
                ProcessedAt = DateTime.UtcNow
            };

            _context.Payments.Add(refund);

            var totalRefunded = (await _context.Payments
                .Where(p => p.OrderId == payment.OrderId && p.Amount < 0)
                .SumAsync(p => Math.Abs(p.Amount))) + refundAmount;

            payment.Status = totalRefunded >= payment.Amount ? PaymentStatus.Refunded : PaymentStatus.PartiallyRefunded;
            payment.UpdatedAt = DateTime.UtcNow;

            var order = await _context.Orders.FindAsync(payment.OrderId);
            if (order != null)
            {
                order.PaymentStatus = totalRefunded >= payment.Amount ? OrderPaymentStatus.Refunded : OrderPaymentStatus.PartiallyRefunded;
                order.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            return await GetPaymentByIdAsync(refund.Id) ?? throw new InvalidOperationException("Failed to retrieve refund payment");
        }

        public async Task<bool> ValidatePaymentAsync(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null)
            {
                return false;
            }

            await Task.Delay(100); 

            return payment.Status == PaymentStatus.Completed;
        }

        public async Task<decimal> CalculateRefundAmountAsync(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null)
            {
                return 0;
            }

            var totalRefunds = await _context.Payments
                .Where(p => p.OrderId == payment.OrderId && p.Amount < 0)
                .SumAsync(p => Math.Abs(p.Amount));

            return Math.Max(0, payment.Amount - totalRefunds);
        }

        private string GenerateTransactionId()
        {
            return $"TXN-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }
    }
}
