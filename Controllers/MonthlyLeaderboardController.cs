using Microsoft.AspNetCore.Mvc;
using ZestrApi.Interfaces;

namespace ZestrApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyLeaderboardController : ControllerBase
    {
        private readonly IMonthlyLeaderboardService _monthlyLeaderboardService;

        public MonthlyLeaderboardController(IMonthlyLeaderboardService monthlyLeaderboardService)
        {
            _monthlyLeaderboardService = monthlyLeaderboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMonthlyLeaderboard([FromQuery] int year, [FromQuery] int month)
        {
            var leaderboard = await _monthlyLeaderboardService.GetMonthlyLeaderboard(year, month);
            return Ok(leaderboard);
        }
    }
}