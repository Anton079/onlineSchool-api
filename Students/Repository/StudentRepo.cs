using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Exceptions;
using online_school_api.Data;
using online_school_api.Enrolments.Dtos;
using online_school_api.Enrolments.Exceptions;
using online_school_api.Enrolments.Models;
using online_school_api.Students.Dtos;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Mappers;
using online_school_api.Students.Model;

namespace online_school_api.Students.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Student

        public async Task<GetAllStudentsDto> GetAllAsync()
        {
             var students = await _context.Students
                                  .Include(s => s.Books)
                                  .Include(s => s.Enrolments)
                                      .ThenInclude(e => e.Course)
                                  .AsNoTracking()
                                  .ToListAsync();

            var mapped = _mapper.Map<List<StudentResponse>>(students);

            return new GetAllStudentsDto
            {
                ListStudent = mapped
            };

        }

        public async Task<StudentResponse> FindByNameStudentAsync(string name)
        {
            Student searched = await _context.Students.FirstOrDefaultAsync(n => n.Name.Equals(name));

            StudentResponse response = _mapper.Map<StudentResponse>(searched);

            return response;
        }

        public async Task<StudentResponse> FindByIdAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Books)
                .Include(s => s.Enrolments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return null;

            return _mapper.Map<StudentResponse>(student);
        }

        public async Task<Student?> GetEntityByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<StudentResponse> CreateStudentAsync(StudentRequest studentRequest)
        {
          

            var studentEntity = _mapper.Map<Student>(studentRequest);

            await _context.Students.AddAsync(studentEntity);
            await _context.SaveChangesAsync();
            var studentResponse = _mapper.Map<StudentResponse>(studentEntity);
            return studentResponse;
        }

        public async Task<StudentResponse> UpdateStudent(int id ,StudentUpdateRequest update)
        {

            Student exist = await _context.Students.FindAsync(id);

            if (update.Name != null)
            {
                exist.Name = update.Name;
            }
            if (update.Email != null)
            {
                exist.Email = update.Email;
            }
            if (update.Age.HasValue)
            {
                exist.Age = update.Age.Value;
            }
            if(update.University!=null)
            {
                exist.University = update.University;
            }

            _context.Students.Update(exist);
            await _context.SaveChangesAsync();
            StudentResponse response = _mapper.Map<StudentResponse>(exist);

            return response;






        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentResponse> DeleteStudentAsync(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            StudentResponse response = _mapper.Map<StudentResponse>(student);

            _context.Remove(student);
            await _context.SaveChangesAsync();

            return response;



        }

        //Book

        public async Task<BookResponse>  DeleteBookAsync (int idstudent,int idbook)
        {
            Student student = await GetEntityByIdAsync(idstudent);

            Book searched = student.Books.FirstOrDefault(s => s.Id == idbook);

            if (searched != null)
            {
                student.Books.Remove(searched);
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<BookResponse>(searched);

        }

        public async Task<BookResponse> UpdateBookAsync(int idstudent, int idbook, BookUpdateRequest updatebook)
        {
            Student student = await GetEntityByIdAsync(idstudent);

            Book exist = student.Books.FirstOrDefault(s => s.Id == idbook);

            if (updatebook.Name != null)
            {
                exist.Name = updatebook.Name;

            }
            if (updatebook.StudentId.HasValue)
            {
                exist.StudentId = updatebook.StudentId.Value;

            }

            _context.Books.Update(exist);

            await _context.SaveChangesAsync();

            return _mapper.Map<BookResponse>(exist);
        }


        //Enrolment

        public async Task<EnrolmentResponse> CreateAsync(EnrolmentStudentRequest request)
        {
            var exists = await _context.Enrolments
                .AnyAsync(e => e.StudentId == request.StudentId && e.CourseId == request.CourseId);

            if (exists)
                throw new EnrolmentAlreadyExistsException();

            var enrolment = new Enrolment
            {
                StudentId = request.StudentId,
                CourseId = request.CourseId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();

            return _mapper.Map<EnrolmentResponse>(enrolment);
        }

        public async Task<EnrolmentResponse> AreCourseIdAndStudentIdASync(int studentId, int courseId)
        {
            var enrolment = await _context.Enrolments
                    .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            var student = await _context.Students.FindAsync(studentId);
            var course = await _context.Courses.FindAsync(courseId);

            if (student == null)
                throw new StudentNotFoundException();

            if (course == null)
                throw new CourseNotFoundException();

            var studentResponse = _mapper.Map<StudentResponse>(student);
            var courseResponse = _mapper.Map<CourseStudentsResponse>(course);

            return _mapper.Map<EnrolmentResponse>(enrolment);
        }

        public async Task<EnrolmentResponse> FindByIdEnrolmentAsync(int id)
        {
            Enrolment enrolment = await _context.Enrolments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id); 

              

            EnrolmentResponse response = _mapper.Map<EnrolmentResponse>(enrolment);
            return response;
        }

        public async Task<EnrolmentResponse> DeleteEnrolment(int id)
        {
            Enrolment enrolment = await _context.Enrolments.FindAsync(id);
            EnrolmentResponse response = _mapper.Map<EnrolmentResponse>(enrolment);

            _context.Remove(enrolment);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<EnrolmentResponse> UpdateEnrolmentAsync(int id, EnrolmentStudentRequest update)
        {
            var enrolment = await _context.Enrolments.FindAsync(id);

            if (enrolment == null)
                throw new EnrolmentNotFoundException();

            enrolment.StudentId = update.StudentId;
            enrolment.CourseId = update.CourseId;

            await _context.SaveChangesAsync(); 

            return _mapper.Map<EnrolmentResponse>(enrolment);
        }




    }
}