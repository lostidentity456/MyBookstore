using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagement.Services;
using OnlineBookstoreManagement.Models;

namespace OnlineBookstoreManagement.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IApiService apiService, ILogger<PaymentsController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Pay(int orderId, decimal amount)
        {
            var model = new CreatePaymentDto
            {
                OrderId = orderId,
                Amount = amount,
                PaymentMethod = "Card",
                Currency = "USD"
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(CreatePaymentDto model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                var created = await _apiService.CreatePaymentAsync(model);
                if (created == null)
                {
                    TempData["ErrorMessage"] = "Failed to create payment.";
                    return View(model);
                }

                var processed = await _apiService.ProcessPaymentAsync(new ProcessPaymentDto
                {
                    PaymentId = created.Id,
                    Status = OrderPaymentStatus.Paid,
                    TransactionId = Guid.NewGuid().ToString("N"),
                    Notes = "Simulated success"
                });

                if (processed == null)
                {
                    TempData["ErrorMessage"] = "Failed to process payment.";
                    return View(model);
                }

                TempData["SuccessMessage"] = "Payment successful!";
                return RedirectToAction("Confirmation", "Checkout", new { id = model.OrderId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment for order {OrderId}", model.OrderId);
                TempData["ErrorMessage"] = "An error occurred while processing payment.";
                return View(model);
            }
        }
    }
}


