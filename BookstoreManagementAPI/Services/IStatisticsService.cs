using OnlineBookstoreManagementAPI.DTOs;
using System.Threading.Tasks;

namespace OnlineBookstoreManagementAPI.Services
{
    public interface IStatisticsService
    {
        Task<StatisticsDto> GetDashboardStatisticsAsync();
    }
}