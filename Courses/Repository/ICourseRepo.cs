using online_school_api.Courses.Dtos;

namespace online_school_api.Courses.Repository
{
    public interface ICourseRepo
    {
        Task<List<GetAllCourseDto>> GetAllCoursesAsync();

        Task<CourseStudentsResponse> GetCourseByDepartment(string name);

        Task<CourseStudentsResponse> GetCourseById(int id);

        Task<CourseStudentsResponse> AddCourse(CourseRequest request);

        Task<CourseStudentsResponse> UpdateCourseAsync(int id, CourseUpdateRequest request);

        Task<CourseStudentsResponse> DeleteCourse(int id);

    }
}
