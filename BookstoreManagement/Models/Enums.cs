namespace OnlineBookstoreManagement.Models
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Returned
    }

    public enum OrderPaymentStatus
    {
        Pending,
        Paid,
        Failed,
        Refunded
    }

    public enum UserRole
    {
        Admin,
        StoreOwner,
        Customer
    }
}