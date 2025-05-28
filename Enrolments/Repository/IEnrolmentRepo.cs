
using online_school_api.Enrolments.Dtos;

namespace online_school_api.Enrolments.Repository
{
    public interface IEnrolmentRepo
    {
        Task<GetAllEnrolmentsDto> GetAllEnrolAsync();
    }
}
