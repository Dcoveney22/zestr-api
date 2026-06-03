using ZestrApi.Models;

namespace ZestrApi.Interfaces
{
    public interface IMonthlyLeaderboardService
    {
        Task<IEnumerable<MonthlyLeaderboardEntry>> GetMonthlyLeaderboard(int year, int month);
    }
}