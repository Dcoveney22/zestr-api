using Microsoft.AspNetCore.Mvc;
using ZestrApi.Interfaces;
using ZestrApi.Models;

namespace ZestrApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class WeeklySpecialController : ControllerBase
    {
        //======GET THIS WEEKS SPECIALS=====//
        private readonly IWeeklySpecialService _weeklySpecialService;

        public WeeklySpecialController(IWeeklySpecialService weeklySpecialService)
        {
            _weeklySpecialService = weeklySpecialService;
        }

        [HttpGet("week/{weekCommencing}")]
        public async Task<IActionResult> GetThisWeeksSpecials(DateTime weekCommencing)
        {
            var thisWeeksSpecials = await _weeklySpecialService.GetThisWeeksSpecials(weekCommencing);
            if (thisWeeksSpecials == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(thisWeeksSpecials);
            }
        }

        //====GET SPECIAL BY SPECIFIC ID=====//
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialById(Guid id)
        {
            var weeklySpecial = await _weeklySpecialService.GetSpecialById(id);
            if (weeklySpecial == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(weeklySpecial);
            }
        }

        //===CREATE NEW SPECIAL====///

        [HttpPost]

        public async Task<IActionResult> CreateSpecial([FromBody] WeeklySpecial weeklySpecial)
        {
            var createdSpecial = await _weeklySpecialService.CreateSpecial(weeklySpecial);
            return CreatedAtAction(nameof(GetSpecialById), new { id = createdSpecial.Id }, createdSpecial);
        }


    }
}