using ZestrApi.Models;

namespace ZestrApi.Interfaces
{
    public interface IScoringService
    {
        IEnumerable<LeaderBoardEntry> ScoreLeaderboard(IEnumerable<SaleRecord> salesRecord, IEnumerable<MenuItem> menuItems, IEnumerable<StaffMember> staffMember, IEnumerable<WeeklySpecial> weeklySpecial, DateTime weekCommencing);
    }

}