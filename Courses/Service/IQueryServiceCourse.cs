using online_school_api.Courses.Dtos;

namespace online_school_api.Courses.Service
{
    public interface IQueryServiceCourse
    {
        Task<List<GetAllCourseDto>> GetAll();

        Task<CourseStudentsResponse> GetCourseByDepartmentAsync(string name);
    }
}
