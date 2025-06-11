using online_school_api.system;

namespace online_school_api.Courses.Exceptions
{
    public class CourseNullException:Exception
    {
        public CourseNullException() : base(ExceptionsMessage.CourseNullException) { }
    }
}
