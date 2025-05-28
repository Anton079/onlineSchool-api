using online_school_api.Enrolments.Models;

namespace online_school_api.Enrolments.Dtos
{
    public class GetAllEnrolmentsDto
    {
        public List<EnrolmentResponse> ListEnrolment {  get; set; }
    }
}
