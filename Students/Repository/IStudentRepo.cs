using online_school_api.Books.Dtos;
using online_school_api.Enrolments.Dtos;
using online_school_api.Students.Dtos;
using online_school_api.Students.Model;


namespace online_school_api.Students.Repository
{
    public interface IStudentRepo
    {

        Task<GetAllStudentsDto> GetAllAsync();


        Task<StudentResponse> CreateStudentAsync(StudentRequest studentRequest);
   
        Task<Student?> GetEntityByIdAsync(int id);

        Task<StudentResponse> UpdateStudent(int id, StudentUpdateRequest update);


        Task<StudentResponse> FindByNameStudentAsync(string name);

        Task<StudentResponse> FindByIdAsync(int id);

        Task UpdateAsync(Student student);

        Task<StudentResponse> DeleteStudentAsync(int id);

        Task<BookResponse> DeleteBookAsync(int idstudent, int idBook);

        Task<BookResponse> UpdateBookAsync(int idstudent, int idbook, BookUpdateRequest updatebook);

        //Enrolments

        Task<EnrolmentResponse> CreateAsync(EnrolmentStudentRequest request);
        Task<EnrolmentResponse> AreCourseIdAndStudentIdASync(int studentId, int courseId);
        Task<EnrolmentResponse> FindByIdEnrolmentAsync(int id);
        Task<EnrolmentResponse> DeleteEnrolment(int id);
        Task<EnrolmentResponse> UpdateEnrolmentAsync(int id, EnrolmentStudentRequest update);


    }
}
