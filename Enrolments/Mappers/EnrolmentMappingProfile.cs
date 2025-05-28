using AutoMapper;
using online_school_api.Enrolments.Dtos;
using online_school_api.Enrolments.Models;

namespace online_school_api.Enrolments.Mappers
{
    public class EnrolmentMappingProfile:Profile
    {
        public EnrolmentMappingProfile()
        {
            CreateMap<EnrolmentStudentRequest, Enrolment>();
            CreateMap<Enrolment, EnrolmentResponse>();

       
        }
    }
}
