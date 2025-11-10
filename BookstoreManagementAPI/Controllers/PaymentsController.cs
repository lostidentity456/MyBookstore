using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Services;

namespace OnlineBookstoreManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        /// <summary>
        /// Create a new payment
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            try
            {
                var payment = await _paymentService.CreatePaymentAsync(createPaymentDto);
                return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating payment");
                return StatusCode(500, "An error occurred while creating the payment");
            }
        }

        /// <summary>
        /// Get payment by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPayment(int id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByIdAsync(id);
                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payment with ID {PaymentId}", id);
                return StatusCode(500, "An error occurred while retrieving the payment");
            }
        }

        /// <summary>
        /// Get payments by order ID
        /// </summary>
        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPaymentsByOrder(int orderId)
        {
            try
            {
                var payments = await _paymentService.GetPaymentsByOrderIdAsync(orderId);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payments for order {OrderId}", orderId);
                return StatusCode(500, "An error occurred while retrieving payments");
            }
        }

        /// <summary>
        /// Process a payment
        /// </summary>
        [HttpPost("process")]
        public async Task<ActionResult<PaymentDto>> ProcessPayment(ProcessPaymentDto processPaymentDto)
        {
            try
            {
                var payment = await _paymentService.ProcessPaymentAsync(processPaymentDto);
                return Ok(payment);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment {PaymentId}", processPaymentDto.PaymentId);
                return StatusCode(500, "An error occurred while processing the payment");
            }
        }

        /// <summary>
        /// Refund a payment
        /// </summary>
        [HttpPost("{id}/refund")]
        public async Task<ActionResult<PaymentDto>> RefundPayment(int id, [FromBody] decimal? amount = null)
        {
            try
            {
                var refund = await _paymentService.RefundPaymentAsync(id, amount);
                return Ok(refund);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error refunding payment {PaymentId}", id);
                return StatusCode(500, "An error occurred while refunding the payment");
            }
        }

        /// <summary>
        /// Validate a payment
        /// </summary>
        [HttpPost("{id}/validate")]
        public async Task<ActionResult<object>> ValidatePayment(int id)
        {
            try
            {
                var isValid = await _paymentService.ValidatePaymentAsync(id);
                return Ok(new { valid = isValid });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating payment {PaymentId}", id);
                return StatusCode(500, "An error occurred while validating the payment");
            }
        }

        /// <summary>
        /// Calculate refund amount for a payment
        /// </summary>
        [HttpGet("{id}/refund-amount")]
        public async Task<ActionResult<object>> GetRefundAmount(int id)
        {
            try
            {
                var amount = await _paymentService.CalculateRefundAmountAsync(id);
                return Ok(new { refundAmount = amount });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating refund amount for payment {PaymentId}", id);
                return StatusCode(500, "An error occurred while calculating refund amount");
            }
        }
    }
}
