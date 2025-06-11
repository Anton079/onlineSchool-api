using Microsoft.AspNetCore.Mvc;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Exceptions;
using online_school_api.Courses.Repository;
using online_school_api.Courses.Service;

namespace online_school_api.Courses.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICommandServiceCourse _commandServiceCourse;
        private readonly IQueryServiceCourse _queryServiceCourse;
        public CourseController(ICommandServiceCourse commandServiceCourse, IQueryServiceCourse queryServiceCourse)
        {
            _commandServiceCourse = commandServiceCourse;
            _queryServiceCourse = queryServiceCourse;
        }

        [HttpGet("getAllCourseAsync")]
        public async Task<ActionResult<GetAllCourseDto>> GetAll()
        {
            try
            {
                var response = await _queryServiceCourse.GetAll();
                return Ok(response);
            }catch(CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("addCourse")]
        public async Task<ActionResult<CourseStudentsResponse>> AddCourse([FromBody] CourseRequest request)
        {
            try
            {
                var added = await _commandServiceCourse.AddCourse(request);
                return Ok(added);
            }catch(CourseNullException ex)
            {
                return StatusCode(404, ex.Message);
            }catch (CourseAlreadyExistException ex)
            {
                return StatusCode(409, ex.Message);
            }
        }

        [HttpPut("updateCourse")]
        public async Task<ActionResult<CourseStudentsResponse>> UpdateCrouse([FromQuery] int id, [FromBody] CourseUpdateRequest request)
        {
            try
            {
                var update = await _commandServiceCourse.UpdateCourse(id, request);
                return Ok(update);
            }
            catch (CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("deleteCourse")]
        public async Task<ActionResult<CourseUpdateRequest>> DeleteCourse([FromQuery] int id)
        {
            try
            {
                var delete = await _commandServiceCourse.DeleteCourse(id);
                return Ok(delete);
            }
            catch (CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
