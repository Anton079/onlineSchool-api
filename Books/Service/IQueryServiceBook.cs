using online_school_api.Books.Dtos;

namespace online_school_api.Books.Service
{
    public interface IQueryServiceBook
    {



        Task<GetAllBooksDto> GetAllBooksAsync();






    }
}
