using online_school_api.Enrolments.Models;

namespace online_school_api.Courses.Dtos
{
    public class CourseResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Departament {  get; set; }

        public List<Enrolment> Enrolments { get; set; } = new();
    }
}
