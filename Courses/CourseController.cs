using Microsoft.AspNetCore.Mvc;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Repository;

namespace online_school_api.Courses.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepo _repo;

        public CourseController(ICourseRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("add")]
        public async Task<ActionResult<CourseStudentsResponse>> AddCourse([FromBody] CourseRequest request)
        {
            try
            {
                var added = await _repo.AddCourse(request);
                return Ok(added);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<CourseStudentsResponse>> DeleteCourse(int id)
        {
            try
            {
                var deleted = await _repo.DeleteCourse(id);
                return Ok(deleted);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
