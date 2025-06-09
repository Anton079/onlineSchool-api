using online_school_api.system;

namespace online_school_api.Courses.Exceptions
{
    public class CourseNotFoundException:Exception
    {
        public CourseNotFoundException() :base(ExceptionsMessage.CourseNotFoundException) { }
    }
}
