using Microsoft.EntityFrameworkCore;
using ZestrApi.Data;
using ZestrApi.Interfaces;
using ZestrApi.Models;

namespace ZestrApi.Services
{
    public class MonthlyLeaderboardService : IMonthlyLeaderboardService
    {
        private readonly ZestrDbContext _context;

        public MonthlyLeaderboardService(ZestrDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MonthlyLeaderboardEntry>> GetMonthlyLeaderboard(int year, int month)
        {
            var results = await _context.WeeklyResults
                .Where(r => r.WeekCommencing.Year == year && r.WeekCommencing.Month == month)
                .ToListAsync();

            var staffIds = results.Select(r => r.StaffId).Distinct().ToList();
            var staff = await _context.StaffMembers
                .Where(s => staffIds.Contains(s.Id))
                .ToListAsync();

            var leaderboard = results
                .GroupBy(r => r.StaffId)
                .Select(group =>
                {
                    var staffMember = staff.FirstOrDefault(s => s.Id == group.Key);
                    return new MonthlyLeaderboardEntry
                    {
                        StaffId = group.Key,
                        FullName = staffMember != null
                            ? $"{staffMember.FirstName} {staffMember.LastName}"
                            : string.Empty,
                        PositionPoints = group.Sum(r => (int)r.Position),
                        TotalSalesScore = group.Sum(r => r.WeeklyScore),
                        GoldCount = group.Count(r => r.Position == LeaderboardPosition.Gold),
                        SilverCount = group.Count(r => r.Position == LeaderboardPosition.Silver),
                        BronzeCount = group.Count(r => r.Position == LeaderboardPosition.Bronze)
                    };
                })
                .OrderByDescending(e => e.PositionPoints)
                .ThenByDescending(e => e.TotalSalesScore)
                .ToList();

            for (int i = 0; i < leaderboard.Count; i++)
            {
                leaderboard[i].Place = i + 1;
            }

            return leaderboard;
        }
    }
}