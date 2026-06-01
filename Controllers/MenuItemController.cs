using Microsoft.AspNetCore.Mvc;
using ZestrApi.Interfaces;
using ZestrApi.Models;

namespace ZestrApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase

    {

        // define service
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        //====GET ALL MENU ITEMS====//

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menu = await _menuItemService.GetAllMenuItems();
            return Ok(menu);
        }

        //====GET SINGLE MENU ITEMS====//

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            else
            {
                var menuItemById = await _menuItemService.GetMenuItem(id);
                if (menuItemById == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(menuItemById);
                }
            }
        }

        //=== CREATE MENU ITEM ===//
        [HttpPost]

        public async Task<IActionResult> CreateMenuItem([FromBody] MenuItem menuItem)

        {
            var createdMenuItem = await _menuItemService.CreateMenuItem(menuItem);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = createdMenuItem.Id }, createdMenuItem);
        }


    }
}