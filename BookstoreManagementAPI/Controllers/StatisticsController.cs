using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreManagementAPI.DTOs;
using OnlineBookstoreManagementAPI.Services;
using System.Threading.Tasks;

namespace OnlineBookstoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Secure the endpoint
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        // GET: api/statistics/dashboard
        [HttpGet("dashboard")]
        public async Task<ActionResult<StatisticsDto>> GetDashboardStatistics()
        {
            var stats = await _statisticsService.GetDashboardStatisticsAsync();
            return Ok(stats);
        }
    }
}