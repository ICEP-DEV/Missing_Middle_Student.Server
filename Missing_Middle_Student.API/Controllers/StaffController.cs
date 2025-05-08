using Microsoft.AspNetCore.Mvc;
using Missing_Middle_Student.Model.Models;
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
        [HttpPost("/addTechnician")]
        public IActionResult addTechnician(StaffDTO staff)
        {
            var res = _staffService.CreateTechnician(staff);
            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }

        }
        [HttpPost("/loginTechnician")]
        public IActionResult LoginTechnician(LoginDTO login)
        {
            var res = _staffService.LoginTechnician(login);
            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(403);
            }

        }
        [HttpPost("/loginAdmin")]
        public IActionResult LoginAdmin(LoginDTO login)
        {
            AdminResponse? res = _staffService.LoginAdmin(login);
            if(res != null)
            {
                var response = new Dictionary<string, AdminResponse?>();
                response.Add("data", res);
                return StatusCode(201 , response);
            }
            else
            {
                return StatusCode(403);
            }

        }
        [HttpPost("/addDevice")]
        public IActionResult addDevice(DeviceDTO device)
        {
            var res = _staffService.RegisterDevice(device);
            if (res)
            {
                return StatusCode(201,new Dictionary<string, string> { { "Message","Device Added"} });
            }
            else
            {
                return StatusCode(400);
            }

        }
    }
}
