using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementAPI.Data;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Models;

namespace OnlineBookstoreManagementAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(BookstoreDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Book)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    UserId = o.UserId,
                    SubTotal = o.SubTotal,
                    TaxAmount = o.TaxAmount,
                    ShippingAmount = o.ShippingAmount,
                    DiscountAmount = o.DiscountAmount,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    PaymentStatus = o.PaymentStatus,
                    PaymentMethod = o.PaymentMethod,
                    TransactionId = o.TransactionId,
                    ShippingAddress = o.ShippingAddress,
                    ShippingCity = o.ShippingCity,
                    ShippingState = o.ShippingState,
                    ShippingPostalCode = o.ShippingPostalCode,
                    ShippingCountry = o.ShippingCountry,
                    Notes = o.Notes,
                    ShippedDate = o.ShippedDate,
                    DeliveredDate = o.DeliveredDate,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt,
                    UserName = $"{o.User.FirstName} {o.User.LastName}",
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        BookId = oi.BookId,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice,
                        TotalPrice = oi.TotalPrice,
                        BookTitle = oi.Book.Title,
                        BookImageUrl = oi.Book.ImageUrl
                    }).ToList()
                })
                .ToListAsync();

            return orders;
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Book)
                .Where(o => o.Id == id)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    UserId = o.UserId,
                    SubTotal = o.SubTotal,
                    TaxAmount = o.TaxAmount,
                    ShippingAmount = o.ShippingAmount,
                    DiscountAmount = o.DiscountAmount,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    PaymentStatus = o.PaymentStatus,
                    PaymentMethod = o.PaymentMethod,
                    TransactionId = o.TransactionId,
                    ShippingAddress = o.ShippingAddress,
                    ShippingCity = o.ShippingCity,
                    ShippingState = o.ShippingState,
                    ShippingPostalCode = o.ShippingPostalCode,
                    ShippingCountry = o.ShippingCountry,
                    Notes = o.Notes,
                    ShippedDate = o.ShippedDate,
                    DeliveredDate = o.DeliveredDate,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt,
                    UserName = $"{o.User.FirstName} {o.User.LastName}",
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        BookId = oi.BookId,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice,
                        TotalPrice = oi.TotalPrice,
                        BookTitle = oi.Book.Title,
                        BookImageUrl = oi.Book.ImageUrl
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Book)
                .Where(o => o.UserId == userId)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    UserId = o.UserId,
                    SubTotal = o.SubTotal,
                    TaxAmount = o.TaxAmount,
                    ShippingAmount = o.ShippingAmount,
                    DiscountAmount = o.DiscountAmount,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    PaymentStatus = o.PaymentStatus,
                    PaymentMethod = o.PaymentMethod,
                    TransactionId = o.TransactionId,
                    ShippingAddress = o.ShippingAddress,
                    ShippingCity = o.ShippingCity,
                    ShippingState = o.ShippingState,
                    ShippingPostalCode = o.ShippingPostalCode,
                    ShippingCountry = o.ShippingCountry,
                    Notes = o.Notes,
                    ShippedDate = o.ShippedDate,
                    DeliveredDate = o.DeliveredDate,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt,
                    UserName = $"{o.User.FirstName} {o.User.LastName}",
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        BookId = oi.BookId,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice,
                        TotalPrice = oi.TotalPrice,
                        BookTitle = oi.Book.Title,
                        BookImageUrl = oi.Book.ImageUrl
                    }).ToList()
                })
                .ToListAsync();

            return orders;
        }

        public async Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto createOrderDto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null) throw new InvalidOperationException("User not found.");

                if (!createOrderDto.OrderItems.Any())
                {
                    throw new InvalidOperationException("Cannot create an order with no items.");
                }

                var bookIds = createOrderDto.OrderItems.Select(i => i.BookId).Distinct().ToList();

                var bookIdParams = string.Join(",", bookIds.Select((_, i) => $"@p{i}"));
                var books = (await _context.Books
                    .FromSqlRaw($"SELECT * FROM Books WITH (UPDLOCK, HOLDLOCK) WHERE Id IN ({bookIdParams})",
                        bookIds.Select((id, i) => new SqlParameter($"@p{i}", id)).ToArray())
                    .ToListAsync())
                    .ToDictionary(b => b.Id);

                var orderItems = new List<OrderItem>();
                decimal subTotal = 0;

                foreach (var itemDto in createOrderDto.OrderItems)
                {
                    if (itemDto.Quantity <= 0) throw new InvalidOperationException("Order quantity must be a positive number.");
                    if (!books.TryGetValue(itemDto.BookId, out var book)) throw new InvalidOperationException($"Book with ID {itemDto.BookId} could not be found.");

                    if (book.StockQuantity < itemDto.Quantity)
                    {
                        throw new InvalidOperationException($"Insufficient stock for '{book.Title}'. Requested: {itemDto.Quantity}, Available: {book.StockQuantity}.");
                    }

                    book.StockQuantity -= itemDto.Quantity;
                    var orderItem = new OrderItem
                    {
                        BookId = itemDto.BookId,
                        Quantity = itemDto.Quantity,
                        UnitPrice = book.CurrentPrice,
                        TotalPrice = book.CurrentPrice * itemDto.Quantity
                    };
                    orderItems.Add(orderItem);
                    subTotal += orderItem.TotalPrice;
                }

                var taxAmount = subTotal * 0.08m;
                var shippingAmount = subTotal > 50 ? 0 : 5.99m;
                var totalAmount = subTotal + taxAmount + shippingAmount;

                var order = new Order
                {
                    OrderNumber = $"ORD-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..8].ToUpper()}",
                    UserId = userId,
                    SubTotal = subTotal,
                    TaxAmount = taxAmount,
                    ShippingAmount = shippingAmount,
                    DiscountAmount = 0,
                    TotalAmount = totalAmount,
                    Status = OrderStatus.Pending,
                    PaymentStatus = OrderPaymentStatus.Pending,
                    ShippingAddress = createOrderDto.ShippingAddress ?? user.Address,
                    ShippingCity = createOrderDto.ShippingCity ?? user.City,
                    ShippingState = createOrderDto.ShippingState ?? user.State,
                    ShippingPostalCode = createOrderDto.ShippingPostalCode ?? user.PostalCode,
                    ShippingCountry = createOrderDto.ShippingCountry ?? user.Country,
                    Notes = createOrderDto.Notes,
                    CreatedAt = DateTime.UtcNow,
                    OrderItems = orderItems
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new OrderDto
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    UserId = order.UserId,
                    SubTotal = order.SubTotal,
                    TaxAmount = order.TaxAmount,
                    ShippingAmount = order.ShippingAmount,
                    DiscountAmount = order.DiscountAmount,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status,
                    PaymentStatus = order.PaymentStatus,
                    ShippingAddress = order.ShippingAddress,
                    ShippingCity = order.ShippingCity,
                    ShippingState = order.ShippingState,
                    ShippingPostalCode = order.ShippingPostalCode,
                    ShippingCountry = order.ShippingCountry,
                    Notes = order.Notes,
                    CreatedAt = order.CreatedAt,
                    UserName = $"{user.FirstName} {user.LastName}",
                    OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        BookId = oi.BookId,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice,
                        TotalPrice = oi.TotalPrice,
                        BookTitle = books[oi.BookId].Title,
                        BookImageUrl = books[oi.BookId].ImageUrl
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error creating order for user {UserId}. Transaction rolled back.", userId);
                throw;
            }
        }

        public async Task<OrderDto?> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto updateOrderStatusDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return null;

            order.Status = updateOrderStatusDto.Status;
            order.UpdatedAt = DateTime.UtcNow;

            if (updateOrderStatusDto.Status == OrderStatus.Shipped && order.ShippedDate == null)
            {
                order.ShippedDate = DateTime.UtcNow;
            }
            else if (updateOrderStatusDto.Status == OrderStatus.Delivered && order.DeliveredDate == null)
            {
                order.DeliveredDate = DateTime.UtcNow;
            }

            if (!string.IsNullOrEmpty(updateOrderStatusDto.Notes))
            {
                order.Notes = updateOrderStatusDto.Notes;
            }

            await _context.SaveChangesAsync();

            return await GetOrderByIdAsync(order.Id);
        }

        public async Task<bool> CancelOrderAsync(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var order = await _context.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (order == null || order.Status == OrderStatus.Cancelled) return false;

                if (order.Status != OrderStatus.Pending && order.Status != OrderStatus.Confirmed)
                {
                    return false;
                }

                var bookIds = order.OrderItems.Select(i => i.BookId).ToList();
                var booksToUpdate = await _context.Books
                    .Where(b => bookIds.Contains(b.Id))
                    .ToDictionaryAsync(b => b.Id);

                foreach (var item in order.OrderItems)
                {
                    if (booksToUpdate.TryGetValue(item.BookId, out var book))
                    {
                        book.StockQuantity += item.Quantity;
                    }
                }

                order.Status = OrderStatus.Cancelled;
                order.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error cancelling order {OrderId}. Transaction rolled back.", id);
                throw;
            }
        }

        public async Task<decimal> CalculateOrderTotalAsync(CreateOrderDto createOrderDto)
        {
            decimal subTotal = 0;
            var bookIds = createOrderDto.OrderItems.Select(i => i.BookId).ToList();
            var books = await _context.Books.Where(b => bookIds.Contains(b.Id)).ToDictionaryAsync(k => k.Id);

            foreach (var itemDto in createOrderDto.OrderItems)
            {
                if (!books.TryGetValue(itemDto.BookId, out var book) || !book.IsActive)
                {
                    throw new InvalidOperationException($"Book {itemDto.BookId} is not available");
                }
                subTotal += book.CurrentPrice * itemDto.Quantity;
            }

            var taxAmount = subTotal * 0.08m;
            var shippingAmount = subTotal > 50 ? 0 : 5.99m;

            return subTotal + taxAmount + shippingAmount;
        }
    }
}