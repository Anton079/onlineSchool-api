using online_school_api.Courses.Dtos;

namespace online_school_api.Courses.Repository
{
    public interface ICourseRepo
    {
        Task<CourseResponse> AddCourse(CourseRequest request);

        Task<CourseResponse> DeleteCourse(int id);
    }
}
