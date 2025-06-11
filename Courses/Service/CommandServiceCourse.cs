using online_school_api.Courses.Dtos;
using online_school_api.Courses.Exceptions;
using online_school_api.Courses.Repository;
using online_school_api.Students.Dtos;
using online_school_api.Students.Exceptions;

namespace online_school_api.Courses.Service
{
    public class CommandServiceCourse : ICommandServiceCourse
    {
        public readonly ICourseRepo _repo;
        public CommandServiceCourse(ICourseRepo repo)
        {
            _repo = repo;
        }

        public async Task<CourseStudentsResponse> AddCourse(CourseRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Department))
                throw new CourseNullException();

            CourseStudentsResponse verif = await _repo.GetCourseByDepartment(req.Department);

            if(verif == null)
            {
                CourseStudentsResponse response = await _repo.AddCourse(req);

                return response;
            }

            throw new CourseAlreadyExistException();
        }

        public async Task<CourseStudentsResponse> UpdateCourse(int id, CourseUpdateRequest update)
        {
            var courseEntity = await _repo.GetCourseById(id);
            if (courseEntity == null)
                throw new CourseNotFoundException();

            var response = await _repo.UpdateCourseAsync(id, update);
            return response;
        }

        public async Task<CourseStudentsResponse> DeleteCourse(int id)
        {
            CourseStudentsResponse vef = await _repo.GetCourseById(id);

            if (vef != null)
            {
                CourseStudentsResponse response = await _repo.DeleteCourse(id);

                return response;
            }
            throw new CourseNotFoundException();
        }
    }
}
