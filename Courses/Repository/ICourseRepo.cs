using online_school_api.Courses.Dtos;

namespace online_school_api.Courses.Repository
{
    public interface ICourseRepo
    {
        Task<CourseStudentsResponse> AddCourse(CourseRequest request);

        Task<CourseStudentsResponse> DeleteCourse(int id);
    }
}
