namespace OnlineBookstoreManagementAPI.Models
{
    public enum OrderPaymentStatus
    {
        Pending = 0,
        Paid = 1,
        Failed = 2,
        Refunded = 3,
        PartiallyRefunded = 4
    }
}