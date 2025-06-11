using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Models;
using online_school_api.Data;

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

        public async Task<List<GetAllCourseDto>> GetAllCoursesAsync()
        {
            var courses = await _dbContext.Courses
                .Include(c => c.Enrolments)
                .ThenInclude(e => e.Student)
                .ToListAsync();

            return _mapper.Map<List<GetAllCourseDto>>(courses);
            
        }

        public async Task<CourseStudentsResponse> GetCourseByDepartment(string name)
        {
            Course searched = await _dbContext.Courses.FirstOrDefaultAsync(d => d.Department.Equals(name));

            CourseStudentsResponse response  = _mapper.Map<CourseStudentsResponse>(searched);

            return response;
        }

        public async Task<CourseStudentsResponse> GetCourseById(int id)
        {
            Course searched = await _dbContext.Courses.FirstOrDefaultAsync(d => d.Id.Equals(id));

            CourseStudentsResponse response = _mapper.Map<CourseStudentsResponse>(searched);

            return response;
        }

        public async Task<CourseStudentsResponse> AddCourse(CourseRequest request)
        {
            var course = _mapper.Map<Course>(request);

            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CourseStudentsResponse>(course);
        }

        public async Task<CourseStudentsResponse> UpdateCourseAsync(int id, CourseUpdateRequest request)
        {
            var course = await _dbContext.Courses.FindAsync(id);

            if (request.Name != null)
                course.Name = request.Name;

            if (request.Department != null)
                course.Department = request.Department;

            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CourseStudentsResponse>(course);
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
