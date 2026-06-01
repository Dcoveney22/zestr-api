

using ZestrApi.Models;

namespace ZestrApi.Interfaces
{

    public interface IStaffService
    {
        //GetAll signature
        Task<IEnumerable<StaffMember>> GetAllStaff();

        Task<StaffMember?> GetStaffMember(Guid id);

        Task<StaffMember> CreateStaff(StaffMember staffMember);
    }

}


