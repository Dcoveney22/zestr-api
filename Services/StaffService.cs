
using ZestrApi.Data;
using ZestrApi.Interfaces;
using ZestrApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ZestrApi.Services
{

    public class StaffService : IStaffService

    {
        private readonly ZestrDbContext _context;
        public StaffService(ZestrDbContext context)

        {
            _context = context;
        }

        //====GET ALL STAFF CALL=======//
        public async Task<IEnumerable<StaffMember>> GetAllStaff()
        {
            return await _context.StaffMembers.ToListAsync();
        }

        //====GET SINGLE STAFF CALL=======//
        public async Task<StaffMember?> GetStaffMember(Guid id)
        {

            var foundStaff = await _context.StaffMembers.FirstOrDefaultAsync(s => s.Id == id);
            return foundStaff;

        }

        //====CREATE STAFF CALL=======//
        public async Task<StaffMember> CreateStaff(StaffMember staffMember)
        {
            await _context.StaffMembers.AddAsync(staffMember);
            await _context.SaveChangesAsync();
            return staffMember;
        }
    }
}