using online_school_api.Courses.Dtos;

namespace online_school_api.Courses.Service
{
    public interface ICommandServiceCourse
    {
        Task<CourseStudentsResponse> AddCourse(CourseRequest req);

        Task<CourseStudentsResponse> UpdateCourse(int id, CourseUpdateRequest update);

        Task<CourseStudentsResponse> DeleteCourse(int id);
    }
}
