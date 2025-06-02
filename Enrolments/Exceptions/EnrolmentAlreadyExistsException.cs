using online_school_api.system;

namespace online_school_api.Enrolments.Exceptions
{
    public class EnrolmentAlreadyExistsException:Exception
    {
        public EnrolmentAlreadyExistsException() : base(ExceptionsMessage.EnrolmentAlreadyExistsException) { }
    }
}
