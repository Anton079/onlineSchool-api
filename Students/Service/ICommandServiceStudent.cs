using online_school_api.Books.Dtos;
using online_school_api.Students.Dtos;
using online_school_api.Students.Model;

namespace online_school_api.Students.Service
{
    public interface ICommandServiceStudent
    {

        Task<StudentResponse> CreateAsync(StudentRequest studentRequest);

        Task<BookResponse> AddBookAsync(BookRequest bookRequest);

        Task<StudentResponse> UpdateStudentAsync(int id,StudentUpdateRequest update);

        Task<StudentResponse> DeleteStudentAsync(int id);


        Task<BookResponse> DeleteBookAsync(int idstudent,int idbook);


        Task<BookResponse> UpdateBookAsync(int idstudent, int idbook, BookUpdateRequest updatebook);









    }
}
