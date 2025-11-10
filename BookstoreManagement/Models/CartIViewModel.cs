namespace OnlineBookstoreManagement.Models
{
    public class CartItemViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
    }

    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public decimal GrandTotal => Items.Sum(i => i.Total);
    }
}
