using Microsoft.AspNetCore.Mvc;
using online_school_api.Students.Dtos;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Service;
using System.Security.AccessControl;
using online_school_api.Books.Dtos;
using online_school_api.Books.Exceptions;

namespace online_school_api.Students
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class StudentController:ControllerBase
    {

        private readonly IQueryServiceStudent _query;
        private readonly ICommandServiceStudent _command;

        public StudentController(ICommandServiceStudent command,IQueryServiceStudent query)
        {
            _query = query;
            _command = command;

        }

        [HttpGet("allStudents")]
        public async Task<ActionResult<GetAllStudentsDto>> GetAllStudentsAsync()
        {
            try
            {
                GetAllStudentsDto response = await _query.GetAllAsync();

               return  Ok(response);

            }catch(StudentNotFoundException nf)
            {
                return NotFound(nf.Message);
            }

        }


        [HttpPost("create")]
        public async Task<ActionResult<StudentResponse>> CreateAsync([FromBody]StudentRequest studentRequest)
        {
            try
            {
                StudentResponse response = await _command.CreateAsync(studentRequest);
                return Created("", response);

            }catch(StudentAlreadyExistExcept ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("addBook")]
        public async Task<ActionResult<BookResponse>> AddBookAsync([FromBody] BookRequest bookRequest)
        {
            try
            {
                var response = await _command.AddBookAsync(bookRequest);
                return Created("", response);

            }catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("updateStudent/{id}")]
        public async Task<ActionResult<StudentResponse>> UpdateStudentAsync([FromRoute] int id, [FromBody]StudentUpdateRequest update)
        {
            try
            {
                StudentResponse response = await _command.UpdateStudentAsync(id, update);

                return Accepted("", response);

            }catch(StudentNotFoundException nf)
            {
                return NotFound(nf.Message);
            }








        }


        [HttpPut("updateBook/{idstudent}/{idbook}")]
        public async Task<ActionResult<BookResponse>> UpdateBookAsync([FromRoute]int idstudent,[FromRoute]int idbook, [FromBody]BookUpdateRequest bookupdate)
        {
            try
            {
                BookResponse response = await _command.UpdateBookAsync(idstudent, idbook, bookupdate);

                return Accepted("", response);

            }catch(BookNotFoundException nf)
            {
                return NotFound(nf.Message);
            }
        }


        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<StudentResponse>> DeleteStudentAsync([FromRoute]int id)
        {
            try
            {
                StudentResponse response = await _command.DeleteStudentAsync(id);
                return Accepted("", response);

            }
            catch(StudentNotFoundException nf)
            {
                return NotFound(nf.Message);
            }





        }


        [HttpDelete("DeleteBook/{studentid}/{bookid}")]
        public async Task<ActionResult<BookResponse>> DeleteBookAsync([FromRoute] int studentid, [FromRoute] int bookid)
        {

            try
            {

                BookResponse response = await _command.DeleteBookAsync(studentid, bookid);

                return Accepted("", response);



            }catch(BookNotFoundException nf)
            {
                return NotFound(nf.Message);
            }
            catch (StudentNotFoundException nf)
            {
                return NotFound(nf.Message);
            }




        }
    }
}
