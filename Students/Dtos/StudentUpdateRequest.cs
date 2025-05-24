using System.ComponentModel.DataAnnotations;

namespace online_school_api.Students.Dtos
{
    public class StudentUpdateRequest
    {


        
        public string ?Email { get; set; }

        
        public string ?Name { get; set; }
       
        public int? Age { get; set; }
        
        public string? University { get; set; }


















    }
}
