using Microsoft.AspNetCore.Mvc;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Services.Studentservices;

namespace Missing_Middle_Student.API.Controllers.StudentComtroller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicantService _appicantService;

        public ApplicationController(IApplicantService appicantService)
        {
            _appicantService = appicantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicant(Applicant Applicant, IFormFile SupportingDoc, IFormFile AcademicRec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
           
            if (AcademicRec != null && AcademicRec.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await AcademicRec.CopyToAsync(memoryStream);
                Applicant.Accademic_record = memoryStream.ToArray(); // Assuming `AcademicRecord` is a byte[] property on Applicant
            }

            if (SupportingDoc != null && SupportingDoc.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await SupportingDoc.CopyToAsync(memoryStream);
                Applicant.SupportingDoc = memoryStream.ToArray(); // Assuming `AcademicRecord` is a byte[] property on Applicant
            }

            await _appicantService.AddApplicantAsync(Applicant);


            return Ok(new {message = "Applicant saved successfully"});
        }



    }
}
