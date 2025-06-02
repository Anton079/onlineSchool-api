
using online_school_api.Enrolments.Dtos;

namespace online_school_api.Enrolments.Repository
{
    public interface IEnrolmentRepo
    {
        Task<GetAllEnrolmentsDto> GetAllEnrolAsync();
        Task<EnrolmentResponse> CreateAsync(EnrolmentStudentRequest request);
        Task<EnrolmentResponse> AreCourseIdAndStudentIdASync(int studentId, int courseId);
        Task<EnrolmentResponse> FindByIdAsync(int id);
        Task<EnrolmentResponse> DeleteEnrolment(int id);
    }
}
