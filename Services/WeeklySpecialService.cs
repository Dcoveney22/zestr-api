using ZestrApi.Data;
using ZestrApi.Interfaces;
using ZestrApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ZestrApi.Services
{
    public class WeeklySpecialService : IWeeklySpecialService

    {
        private readonly ZestrDbContext _context;

        public WeeklySpecialService(ZestrDbContext context)
        {
            _context = context;
        }

        //====GET WEEKLY SPECIAL FOR THIS WEEK CALL=====//

        public async Task<IEnumerable<WeeklySpecial>> GetThisWeeksSpecials(DateTime weekCommencing)
        {
            var utcDate = DateTime.SpecifyKind(weekCommencing, DateTimeKind.Utc);
            return await _context.WeeklySpecials.Where(s => s.WeekCommencing == utcDate).ToListAsync();

        }

        //===GET SPECIAL BY ID CALL=====//
        public async Task<WeeklySpecial?> GetSpecialById(Guid id)
        {
            var foundWeeklySpecial = await _context.WeeklySpecials.FirstOrDefaultAsync(s => s.Id == id);
            return foundWeeklySpecial;
        }

        public async Task<WeeklySpecial> CreateSpecial(WeeklySpecial weeklySpecial)
        {
            await _context.WeeklySpecials.AddAsync(weeklySpecial);
            await _context.SaveChangesAsync();
            return weeklySpecial;
        }



    }
}