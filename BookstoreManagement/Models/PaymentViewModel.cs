namespace OnlineBookstoreManagement.Models
{
    public class CreatePaymentViewModel
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class PaymentViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ProcessPaymentViewModel
    {
        public int OrderId { get; set; }
        public string Token { get; set; }
    }
}