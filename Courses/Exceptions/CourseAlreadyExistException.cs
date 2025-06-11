using online_school_api.system;

namespace online_school_api.Courses.Exceptions
{
    public class CourseAlreadyExistException:Exception
    {
        public CourseAlreadyExistException() : base(ExceptionsMessage.CourseAlreadyExistException) { }
    }
}
