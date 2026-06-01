using Microsoft.AspNetCore.Mvc;
using ZestrApi.Interfaces;
using ZestrApi.Models;

namespace ZestrApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase

    {
        //===== GET ALL STAFF ======//
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staff = await _staffService.GetAllStaff();
            return Ok(staff);
        }

        //==== GET STAFF BY ID ====//

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            else
            {
                var staffById = await _staffService.GetStaffMember(id);
                if (staffById == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(staffById);
                }

            }

        }

        //==== CREATE STAFF MEMBER ====//
        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] StaffMember staffMember)

        {
            var createdStaff = await _staffService.CreateStaff(staffMember);
            return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.Id }, createdStaff);
        }

    }

}