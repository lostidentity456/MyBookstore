using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Services;
using System.Security.Claims;

namespace OnlineBookstoreManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// Get all orders (Admin/Store Owner only)
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all orders");
                return StatusCode(500, "An error occurred while retrieving orders");
            }
        }

        /// <summary>
        /// Get order by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound();
                }

                // Check if user can access this order
                var userId = GetCurrentUserId();
                if (order.UserId != userId && !User.IsInRole("Admin") && !User.IsInRole("StoreOwner"))
                {
                    return Forbid();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order with ID {OrderId}", id);
                return StatusCode(500, "An error occurred while retrieving the order");
            }
        }

        /// <summary>
        /// Get orders for current user
        /// </summary>
        [HttpGet("my-orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetMyOrders()
        {
            try
            {
                var userId = GetCurrentUserId();
                var orders = await _orderService.GetOrdersByUserIdAsync(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders for user {UserId}", GetCurrentUserId());
                return StatusCode(500, "An error occurred while retrieving orders");
            }
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var order = await _orderService.CreateOrderAsync(userId, createOrderDto);
                return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order for user {UserId}", GetCurrentUserId());
                return StatusCode(500, "An error occurred while creating the order");
            }
        }

        /// <summary>
        /// Update order status (Admin/Store Owner only)
        /// </summary>
        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<ActionResult<OrderDto>> UpdateOrderStatus(int id, UpdateOrderStatusDto updateOrderStatusDto)
        {
            try
            {
                var order = await _orderService.UpdateOrderStatusAsync(id, updateOrderStatusDto);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order status for order {OrderId}", id);
                return StatusCode(500, "An error occurred while updating the order status");
            }
        }

        /// <summary>
        /// Cancel an order
        /// </summary>
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            try
            {
                var userId = GetCurrentUserId();
                var order = await _orderService.GetOrderByIdAsync(id);
                
                if (order == null)
                {
                    return NotFound();
                }

                // Check if user can cancel this order
                if (order.UserId != userId && !User.IsInRole("Admin") && !User.IsInRole("StoreOwner"))
                {
                    return Forbid();
                }

                var result = await _orderService.CancelOrderAsync(id);
                if (!result)
                {
                    return BadRequest("Order cannot be cancelled");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling order {OrderId}", id);
                return StatusCode(500, "An error occurred while cancelling the order");
            }
        }

        /// <summary>
        /// Calculate order total
        /// </summary>
        [HttpPost("calculate-total")]
        public async Task<ActionResult<object>> CalculateOrderTotal(CreateOrderDto createOrderDto)
        {
            try
            {
                var total = await _orderService.CalculateOrderTotalAsync(createOrderDto);
                return Ok(new { total });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating order total");
                return StatusCode(500, "An error occurred while calculating order total");
            }
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (int.TryParse(userIdClaim, out int userId))
            {
                return userId;
            }
            throw new UnauthorizedAccessException("Invalid user ID in token");
        }
    }
}
