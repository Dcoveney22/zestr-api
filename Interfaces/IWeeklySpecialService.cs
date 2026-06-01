using ZestrApi.Models;

namespace ZestrApi.Interfaces
{

    public interface IWeeklySpecialService
    {
        Task<IEnumerable<WeeklySpecial>> GetThisWeeksSpecials(DateTime weekCommencing);

        Task<WeeklySpecial?> GetSpecialById(Guid id);

        Task<WeeklySpecial> CreateSpecial(WeeklySpecial weeklySpecial);



    }
}