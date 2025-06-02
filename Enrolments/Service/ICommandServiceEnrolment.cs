using online_school_api.Enrolments.Dtos;

namespace online_school_api.Enrolments.Service
{
    public interface ICommandServiceEnrolment
    {
        Task<EnrolmentResponse> CreateEnrolmentAsync(EnrolmentStudentRequest request);
        Task<EnrolmentResponse> UpdateEnrolmentAsync(int id, EnrolmentStudentRequest update);
        Task<EnrolmentResponse> DeleteEnrolmentAsync(int id);
    }
}
