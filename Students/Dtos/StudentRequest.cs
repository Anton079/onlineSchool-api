using online_school_api.Books.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using online_school_api.Books.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace online_school_api.Students.Dtos
{
    public class StudentRequest
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string University { get; set; }

    
    }
}
