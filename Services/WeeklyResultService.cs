using ZestrApi.Data;
using ZestrApi.Interfaces;
using ZestrApi.Models;

namespace ZestrApi.Services
{
    public class WeeklyResultService : IWeeklyResultService
    {
        private readonly ZestrDbContext _context;

        public WeeklyResultService(ZestrDbContext context)
        {
            _context = context;
        }

        public async Task SaveWeeklyResult(IEnumerable<LeaderBoardEntry> topThree, DateTime weekCommencing)
        {
            var results = topThree.Select(entry => new WeeklyResult
            {
                Id = Guid.NewGuid(),
                StaffId = entry.StaffId,
                WeekCommencing = weekCommencing,
                WeeklyScore = entry.TotalScore,
                Position = entry.Place switch
                {
                    1 => LeaderboardPosition.Gold,
                    2 => LeaderboardPosition.Silver,
                    3 => LeaderboardPosition.Bronze,
                    _ => throw new ArgumentException($"Invalid place: {entry.Place}")
                }
            }).ToList();

            await _context.WeeklyResults.AddRangeAsync(results);
            await _context.SaveChangesAsync();
        }
    }
}