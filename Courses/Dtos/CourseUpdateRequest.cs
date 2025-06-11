using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace online_school_api.Courses.Dtos
{
    public class CourseUpdateRequest
    {
        public string? Name { get; set; }

        public string? Department { get; set; }
    }
}
