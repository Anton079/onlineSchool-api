using Microsoft.AspNetCore.Mvc;
using online_school_api.Enrolments.Dtos;
using online_school_api.Enrolments.Service;

namespace online_school_api.Enrolments.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentController : ControllerBase
    {
        private readonly ICommandServiceEnrolment _commandService;

        public EnrolmentController(ICommandServiceEnrolment commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnrolment([FromBody] EnrolmentStudentRequest request)
        {
            try
            {
                var result = await _commandService.CreateEnrolmentAsync(request);
                return Ok(result);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrolment(int id, [FromBody] EnrolmentStudentRequest request)
        {
            try
            {
                var updated = await _commandService.UpdateEnrolmentAsync(id, request);
                return Ok(updated);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrolment(int id)
        {
            try
            {
                var deleted = await _commandService.DeleteEnrolmentAsync(id);
                return Ok(deleted);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
