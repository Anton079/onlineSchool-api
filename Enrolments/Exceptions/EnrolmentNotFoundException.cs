using online_school_api.system;

namespace online_school_api.Enrolments.Exceptions
{
    public class EnrolmentNotFoundException:Exception
    {
        public EnrolmentNotFoundException() :base(ExceptionsMessage.EnrolmentNotFoundException) { }
    }
}
