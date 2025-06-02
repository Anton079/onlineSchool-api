using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.EntityFrameworkCore;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Models;
using online_school_api.Data;
using online_school_api.Enrolments.Dtos;
using online_school_api.Enrolments.Exceptions;
using online_school_api.Enrolments.Models;
using online_school_api.Students.Dtos;
using online_school_api.Students.Model;

namespace online_school_api.Enrolments.Repository
{
    public class EnrolmentRepo:IEnrolmentRepo
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public EnrolmentRepo(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAllEnrolmentsDto> GetAllEnrolAsync()
        {
            var enrolments = await _dbContext.Enrolments
                .Include(e => e.Student )
                .ToListAsync();

            var mapperd = _mapper .Map<List<EnrolmentResponse>>(enrolments);

            return new GetAllEnrolmentsDto
            {
                ListEnrolment = mapperd
            };
        }

        public async Task<EnrolmentResponse> CreateAsync(EnrolmentStudentRequest request)
        {
            var exists = await _dbContext.Enrolments
                .AnyAsync(e => e.StudentId == request.StudentId && e.CourseId == request.CourseId);

            if (exists)
                throw new EnrolmentAlreadyExistsException();

            var enrolment = new Enrolment
            {
                StudentId = request.StudentId,
                CourseId = request.CourseId,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Enrolments.Add(enrolment);
            await _dbContext.SaveChangesAsync();

            return new EnrolmentResponse
            {
                StudentId = enrolment.StudentId,
                CourseId = enrolment.CourseId,
                CreatedAt = enrolment.CreatedAt
            };
        }

        public async Task<EnrolmentResponse> AreCourseIdAndStudentIdASync(int studentId, int courseId)
        {
            var enrolment = await _dbContext.Enrolments
                    .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrolment == null)
                throw new EnrolmentNotFoundException();

            var student = await _dbContext.Students.FindAsync(studentId);
            var course = await _dbContext.Courses.FindAsync(courseId);

            if (student == null || course == null)
                throw new EnrolmentNotFoundException();

            var studentResponse = _mapper.Map<StudentResponse>(student);
            var courseResponse = _mapper.Map<CourseResponse>(course);

            return new EnrolmentResponse
            {
                StudentId = enrolment.StudentId,
                CourseId = enrolment.CourseId,
                CreatedAt = enrolment.CreatedAt
            };
        }

        public async Task<EnrolmentResponse> FindByIdAsync(int id)
        {
            Enrolment enrolment = await _dbContext.Enrolments.FindAsync(id);

            EnrolmentResponse response = _mapper.Map<EnrolmentResponse>(enrolment);

            return response;
        }

        public async Task<EnrolmentResponse> DeleteEnrolment(int id)
        {
            Enrolment enrolment = await _dbContext.Enrolments.FindAsync(id);
            EnrolmentResponse response = _mapper.Map<EnrolmentResponse>(enrolment);

            _dbContext.Remove(enrolment);
            await _dbContext.SaveChangesAsync();

            return response;
        }

    }
}
