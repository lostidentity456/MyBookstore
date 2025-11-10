using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Services;

namespace OnlineBookstoreManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;
        private readonly ILogger<RecommendationsController> _logger;

        public RecommendationsController(IRecommendationService recommendationService, ILogger<RecommendationsController> logger)
        {
            _recommendationService = recommendationService;
            _logger = logger;
        }

        /// <summary>
        /// Get personalized recommendations for user
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetUserRecommendations(int userId, [FromQuery] int count = 10)
        {
            try
            {
                var currentUserId = GetCurrentUserId();
                if (currentUserId != userId && !User.IsInRole("Admin") && !User.IsInRole("StoreOwner"))
                {
                    return Forbid();
                }

                var recommendations = await _recommendationService.GetRecommendationsForUserAsync(userId, count);
                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting recommendations for user {UserId}", userId);
                return StatusCode(500, "An error occurred while retrieving recommendations");
            }
        }

        /// <summary>
        /// Get similar books
        /// </summary>
        [HttpGet("similar/{bookId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetSimilarBooks(int bookId, [FromQuery] int count = 5)
        {
            try
            {
                var similarBooks = await _recommendationService.GetSimilarBooksAsync(bookId, count);
                return Ok(similarBooks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting similar books for book {BookId}", bookId);
                return StatusCode(500, "An error occurred while retrieving similar books");
            }
        }

        /// <summary>
        /// Get trending books
        /// </summary>
        [HttpGet("trending")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetTrendingBooks([FromQuery] int count = 10)
        {
            try
            {
                var trendingBooks = await _recommendationService.GetTrendingBooksAsync(count);
                return Ok(trendingBooks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting trending books");
                return StatusCode(500, "An error occurred while retrieving trending books");
            }
        }

        /// <summary>
        /// Get new releases
        /// </summary>
        [HttpGet("new-releases")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetNewReleases([FromQuery] int count = 10)
        {
            try
            {
                var newReleases = await _recommendationService.GetNewReleasesAsync(count);
                return Ok(newReleases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting new releases");
                return StatusCode(500, "An error occurred while retrieving new releases");
            }
        }

        /// <summary>
        /// Update recommendations for user
        /// </summary>
        [HttpPost("update/{userId}")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<IActionResult> UpdateUserRecommendations(int userId)
        {
            try
            {
                await _recommendationService.UpdateRecommendationsForUserAsync(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating recommendations for user {UserId}", userId);
                return StatusCode(500, "An error occurred while updating recommendations");
            }
        }

        /// <summary>
        /// Update all recommendations
        /// </summary>
        [HttpPost("update-all")]
        [Authorize(Roles = "Admin,StoreOwner")]
        public async Task<IActionResult> UpdateAllRecommendations()
        {
            try
            {
                await _recommendationService.UpdateAllRecommendationsAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating all recommendations");
                return StatusCode(500, "An error occurred while updating recommendations");
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
