using online_school_api.Courses.Models;
using online_school_api.Students.Model;

namespace online_school_api.Enrolments.Dtos
{
    public class EnrolmentResponse
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime CreatedAt { get; set; }



        public Student student { get; set; } = new();

        public Course course { get; set; } = new();
    }
}
