namespace OnlineBookstoreManagement.Models
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? TransactionId { get; set; }
        public decimal Amount { get; set; }
        public OrderPaymentStatus Status { get; set; }
        public string? Currency { get; set; }
        public string? Notes { get; set; }
        public string? PaymentDetails { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
    }

    public class CreatePaymentDto
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string? Currency { get; set; } = "USD";
        public string? Notes { get; set; }
        public PaymentDetailsDto? PaymentDetails { get; set; }
    }

    public class PaymentDetailsDto
    {
        public string? CardNumber { get; set; }
        public string? CardHolderName { get; set; }
        public string? ExpiryMonth { get; set; }
        public string? ExpiryYear { get; set; }
        public string? CVV { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingPostalCode { get; set; }
        public string? BillingCountry { get; set; }
    }

    public class ProcessPaymentDto
    {
        public int PaymentId { get; set; }
        public string? TransactionId { get; set; }
        public OrderPaymentStatus Status { get; set; }
        public string? Notes { get; set; }
    }
}
