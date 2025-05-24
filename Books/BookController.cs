using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using Microsoft.AspNetCore.Mvc;
using online_school_api.Books.Service;
using online_school_api.Books.Repository;
using online_school_api.Books.Exceptions;

namespace online_school_api.Books
{
    [ApiController]
    [Route("api/v2/[Controller]")]
    public class BookController:ControllerBase
    {

        private readonly IQueryServiceBook _query;

        public BookController(IQueryServiceBook query)
        {
            _query = query;
        }




        [HttpGet("allBooks")]

        public async Task<ActionResult<GetAllBooksDto>> GetAllBooksAsync()
        {
            try
            {
                GetAllBooksDto response = await _query.GetAllBooksAsync();

                return Ok(response);


            }catch(BookNotFoundException nf)
            {
                return NotFound(nf.Message);
            }

        }


    }
}
