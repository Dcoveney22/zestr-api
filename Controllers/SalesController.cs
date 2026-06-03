using Microsoft.AspNetCore.Mvc;
using ZestrApi.Interfaces;
using ZestrApi.Services;
using Microsoft.EntityFrameworkCore;
using ZestrApi.Models;

namespace ZestrApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase

    {
        private readonly ISalesUploadService _salesUploadService;
        private readonly IScoringService _scoringService;
        private readonly IWeeklySpecialService _weeklySpecialService;
        private readonly IStaffService _staffService;
        private readonly IMenuItemService _menuItemsService;
        private readonly IWeeklyResultService _weeklyResultService;

        public SalesController(ISalesUploadService salesUploadService, IScoringService scoringService, IWeeklySpecialService weeklySpecialService, IStaffService staffService, IMenuItemService menuItemService, IWeeklyResultService weeklyResultService)
        {
            _salesUploadService = salesUploadService;
            _scoringService = scoringService;
            _weeklySpecialService = weeklySpecialService;
            _menuItemsService = menuItemService;
            _staffService = staffService;
            _weeklyResultService = weeklyResultService;
        }


        [HttpPost]
        public async Task<IActionResult> GenerateLeaderboard([FromForm] IFormFile file, [FromForm] DateTime weekCommencing)
        {

            var salesData = await _salesUploadService.ParseCsv(file);
            var thisWeeksSpecials = await _weeklySpecialService.GetThisWeeksSpecials(weekCommencing);
            var allMenuItems = await _menuItemsService.GetAllMenuItems();
            var staffMembers = await _staffService.GetAllStaff();
            var leaderboard = _scoringService.ScoreLeaderboard(salesData, allMenuItems, staffMembers, thisWeeksSpecials, weekCommencing);
            return Ok(leaderboard);

        }

        [HttpPost("confirm")]
        public async Task<IActionResult> SaveWeeklyResult([FromBody] IEnumerable<LeaderBoardEntry> leaderboard, [FromQuery] DateTime weekCommencing)
        {
            await _weeklyResultService.SaveWeeklyResult(leaderboard.Take(3), weekCommencing);
            return Ok();
        }


    }
}