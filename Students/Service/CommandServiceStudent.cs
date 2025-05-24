using AutoMapper;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using online_school_api.Students.Dtos;
using online_school_api.Students.Repository;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Model;
using Microsoft.AspNetCore.Server.IIS.Core;
using online_school_api.Books.Exceptions;
using System.CodeDom;

namespace online_school_api.Students.Service
{
    public class CommandServiceStudent:ICommandServiceStudent
    {

        private readonly IStudentRepo _repo;
        private readonly IMapper _mapper;

        public CommandServiceStudent(IStudentRepo repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }


        //User
        public async  Task<StudentResponse> CreateAsync(StudentRequest student)
        {
            StudentResponse verif = await this._repo.FindByNameStudentAsync(student.Name);

            if(verif== null)
            {
                StudentResponse response = await this._repo.CreateStudentAsync(student);

                return response;
            }
            throw new StudentAlreadyExistExcept();


        }

        public async Task<StudentResponse> UpdateStudentAsync(int id,StudentUpdateRequest update)
        {
            StudentResponse verf = await this._repo.FindByIdAsync(id);
            if(verf != null)
            {
                if(verf is StudentRequest)
                {
                    verf.Name = update.Name ?? verf.Name;
                    verf.Email = update.Email ?? verf.Email;
                    verf.Age = update.Age ?? verf.Age;
                    verf.University = update.University ??verf.University;

                    StudentResponse response = await this._repo.UpdateStudent(id, update);

                    return response;
                }
            }
            throw new StudentNotFoundException();
        }

        public async Task<StudentResponse> DeleteStudentAsync(int id)
        {
            StudentResponse vef = await _repo.FindByIdAsync(id);

            if(vef != null)
            {
                StudentResponse response = await _repo.DeleteStudentAsync(id);

                return response;
            }
            throw new StudentNotFoundException();
        }

        //Book
        public async Task<BookResponse> AddBookAsync(BookRequest bookRequest)
        {
            var student = await _repo.GetEntityByIdAsync(bookRequest.StudentId);

            if (student == null)
                throw new StudentNotFoundException();

            var book = _mapper.Map<Book>(bookRequest);
            book.Created = DateTime.UtcNow;

            student.Books.Add(book);

            await _repo.UpdateAsync(student);

            return _mapper.Map<BookResponse>(book);
        }

        public async Task<BookResponse> UpdateBookAsync(int idstudent, int idbook, BookUpdateRequest updatebook)
        {

            StudentResponse stud = await _repo.FindByIdAsync(idstudent);

            BookResponse book = stud.Books.FirstOrDefault(s => s.Id == idbook);

            if (book != null)
            {
                if (book is BookRequest)
                {
                    book.Name = updatebook.Name ?? book.Name;

                    BookResponse response = await _repo.UpdateBookAsync(idstudent, idbook, updatebook);
                    return response;
                }

            }
            throw new BookNotFoundException();
        }

        public async  Task<BookResponse> DeleteBookAsync(int idstudent,int idBook)
        {
            Student student = await _repo.GetEntityByIdAsync(idstudent);
            Book book = student.Books.FirstOrDefault(s => s.Id == idBook);

            if (student != null)
            {
                if (book != null)
                {
                    BookResponse response = await _repo.DeleteBookAsync(idstudent, idBook);

                    return response;
                }
                throw new BookNotFoundException();
            }
            throw new StudentNotFoundException();
        }




    }
}
