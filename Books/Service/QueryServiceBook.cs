using AutoMapper;
using online_school_api.Books.Dtos;
using online_school_api.Books.Exceptions;
using online_school_api.Books.Repository;

namespace online_school_api.Books.Service
{
    public class QueryServiceBook:IQueryServiceBook
    {
        private readonly IBookRepo _repo;
        private readonly IMapper _mapper;

        public QueryServiceBook(IBookRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<GetAllBooksDto> GetAllBooksAsync()
        {
            GetAllBooksDto response = await _repo.GetAllBooksAsync();

            if (response != null)
            {
                return response;

            }
            throw new BookNotFoundException();

        }
























    }
}
