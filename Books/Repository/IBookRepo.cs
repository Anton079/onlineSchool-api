using online_school_api.Books.Dtos;

namespace online_school_api.Books.Repository
{
    public interface IBookRepo
    {

        Task<GetAllBooksDto> GetAllBooksAsync();




    }
}
