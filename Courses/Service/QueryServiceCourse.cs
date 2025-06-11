using online_school_api.Courses.Dtos;
using online_school_api.Courses.Exceptions;
using online_school_api.Courses.Models;
using online_school_api.Courses.Repository;

namespace online_school_api.Courses.Service
{
    public class QueryServiceCourse:IQueryServiceCourse
    {
        public readonly ICourseRepo _repo;

        public QueryServiceCourse(ICourseRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<GetAllCourseDto>> GetAll()
        {
            List<GetAllCourseDto> response = await _repo.GetAllCoursesAsync();

            if(response == null)
                throw new CourseNotFoundException();

            return response;
        }

        public async Task<CourseStudentsResponse> GetCourseByDepartmentAsync(string name)
        {
            var course = await _repo.GetCourseByDepartment(name);

            if (course == null)
                throw new CourseNotFoundException();

            return course;
        }
    }
}
