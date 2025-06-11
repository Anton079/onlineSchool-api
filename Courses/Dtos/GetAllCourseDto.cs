using online_school_api.Students.Dtos;

namespace online_school_api.Courses.Dtos
{
    public class GetAllCourseDto
    {
        public string Name { get; set; }

        public string Departament { get; set; }

        public List<StudentDto> Student { get; set; }
    }
}
