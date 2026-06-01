using ZestrApi.Interfaces;
using ZestrApi.Models;

namespace ZestrApi.Services
{
    public class ScoringService : IScoringService
    {
        public IEnumerable<LeaderBoardEntry> ScoreLeaderboard(
            IEnumerable<SaleRecord> salesRecords,
            IEnumerable<MenuItem> menuItems,
            IEnumerable<StaffMember> staffMembers,
            IEnumerable<WeeklySpecial> weeklySpecials,
            DateTime weekCommencing)
        {
            // Build lookup: item name -> points value
            var specialLookup = weeklySpecials
                .Join(menuItems,
                    ws => ws.MenuItemId,
                    mi => mi.Id,
                    (ws, mi) => new { mi.Name, Points = (int)ws.SpecialLevel })
                .ToDictionary(x => x.Name, x => x.Points);

            // Calculate scores per staff member
            var scores = salesRecords
                .GroupBy(s => s.StaffId)
                .Select(group => new LeaderBoardEntry
                {
                    StaffId = group.Key,
                    FullName = staffMembers.FirstOrDefault(sm => sm.Id == group.Key)?.FirstName + " " +
                                staffMembers.FirstOrDefault(sm => sm.Id == group.Key)?.LastName ?? string.Empty,
                    TotalScore = group.Sum(record =>
                        record.ItemSales
                            .Where(item => specialLookup.ContainsKey(item.Key))
                            .Sum(item => item.Value * specialLookup[item.Key])),
                    WeekCommencing = weekCommencing
                })
                .OrderByDescending(e => e.TotalScore)
                .ToList();

            // Assign places
            for (int i = 0; i < scores.Count; i++)
            {
                scores[i].Place = i + 1;
            }

            return scores;
        }
    }
}