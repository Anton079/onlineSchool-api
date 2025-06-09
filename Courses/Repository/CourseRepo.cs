using AutoMapper;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Models;
using online_school_api.Data;
using online_school_api.Enrolments.Repository;

namespace online_school_api.Courses.Repository
{
    public class CourseRepo : ICourseRepo
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CourseRepo(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CourseStudentsResponse> AddCourse(CourseRequest request)
        {
            var course = _mapper.Map<Course>(request);

            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            var response = _mapper.Map<CourseStudentsResponse>(course);
            return response;
        }

        public async Task<CourseStudentsResponse> DeleteCourse(int id)
        {
            Course course = await _dbContext.Courses.FindAsync(id);
            CourseStudentsResponse resp = _mapper.Map<CourseStudentsResponse>(course);

            _dbContext.Remove(course);
            await _dbContext.SaveChangesAsync();

            return resp;
        }
    }
}
