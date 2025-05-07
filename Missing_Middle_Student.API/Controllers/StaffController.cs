using Microsoft.AspNetCore.Mvc;
using Missing_Middle_Student.Model.Models.DTOs;
using Missing_Middle_Student.Services.StaffService;

namespace Missing_Middle_Student.API.Controllers
{
    [ApiController]
    [Route("/staff")]
    public class StaffController : ControllerBase
    {
        IStaffService _staffService;
        public StaffController (IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpPost("/addAdmin")]
        public IActionResult addAdmin(StaffDTO staff)
        {
            var res = _staffService.CreateAdmin(staff);
            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
           
        }
        [HttpPost("/addDevice")]
        public IActionResult addDevice(DeviceDTO device)
        {
            var res = _staffService.RegisterDevice(device);
            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }

        }
    }
}
