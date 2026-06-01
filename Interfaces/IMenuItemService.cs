using ZestrApi.Models;

namespace ZestrApi.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItems();

        Task<MenuItem?> GetMenuItem(Guid id);

        Task<MenuItem> CreateMenuItem(MenuItem menuItem);
    }
}