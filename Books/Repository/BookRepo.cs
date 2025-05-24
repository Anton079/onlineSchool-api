using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using online_school_api.Data;

namespace online_school_api.Books.Repository
{
    public class BookRepo:IBookRepo
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;


        public BookRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }


        public async Task<GetAllBooksDto> GetAllBooksAsync()
        {

             var books = await _context.Books.ToListAsync();
            var map = _mapper.Map<List<BookResponse>>(books);

            return new GetAllBooksDto
            {
                bookslist = map

            };
        
        }


    }
}
