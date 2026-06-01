using ZestrApi.Data;
using ZestrApi.Interfaces;
using ZestrApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ZestrApi.Services
{
    public class MenuItemService : IMenuItemService
    {
        //=== DEFINE THE CONTEXT ====//
        private readonly ZestrDbContext _context;
        //=== CONSTRUCTOR ====//
        public MenuItemService(ZestrDbContext context)
        {
            _context = context;
        }

        //====GET ALL MENU ITEMS CALL====//
        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }


        //==== GET SINGLE MENU ITEM =====//
        public async Task<MenuItem?> GetMenuItem(Guid id)
        {
            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
            return menuItem;
        }

        //===== CREATE NEW MENU ITEM ====//

        public async Task<MenuItem> CreateMenuItem(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

    }
}