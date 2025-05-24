using online_school_api.Students.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace online_school_api.Books.Dtos
{
    public class BookResponse
    {



        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        

    }
}
