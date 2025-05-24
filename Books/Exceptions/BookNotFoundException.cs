using online_school_api.system;

namespace online_school_api.Books.Exceptions
{
    public class BookNotFoundException:Exception
    {

        public BookNotFoundException() : base(ExceptionsMessage.BookNotFoundException)
        {


        }

    }
}
