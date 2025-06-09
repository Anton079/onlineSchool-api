using System.Configuration;
using System.Text;

namespace online_school_api.system
{
    public class ExceptionsMessage
    {

        public const string StudentAlreadyExistsExcpt = "The Student already exist";

        public const string StudentNotFoundException = "The Student doesn't exist";

        public const string BookNotFoundException = "The book doesn't exist";

        public const string BookAlreadyExistException = "The Book already exist";


        //Enrolments
        public const string EnrolmentAlreadyExistsException = "Enrolment exista deja";

        public const string EnrolmentNotFoundException = "Enrolment nu a fost gasit";

        //Course 
        public const string CourseNotFoundException = "Course nu a fost gasit!";

    }
}
