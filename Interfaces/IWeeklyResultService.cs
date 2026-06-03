
using ZestrApi.Models;

namespace ZestrApi.Interfaces
{
    public interface IWeeklyResultService
    {
        Task SaveWeeklyResult(IEnumerable<LeaderBoardEntry> topThree, DateTime weekCommencing);
    }
}