using AutoMapper;
using online_school_api.Students.Model;
using online_school_api.Students.Dtos;

namespace online_school_api.Students.Mappers
{
    public class StudentMappingProfile:Profile
    {

        public StudentMappingProfile()
        {
            CreateMap<StudentRequest, Student>();
            CreateMap<Student, StudentResponse>();
            CreateMap<StudentUpdateRequest, Student>();
        

            CreateMap<Student, StudentResponse>()

              .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));












        }















    }
}
