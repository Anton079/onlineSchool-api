using online_school_api.Enrolments.Models;
using online_school_api.Students.Model;

namespace online_school_api.Courses.Dtos
{
    public class CourseStudentsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Departament {  get; set; }

        public virtual List<Student> Students { get; set; } = new();
        public virtual List<Enrolment> Enrolments { get; set; } = new();
    }
}
