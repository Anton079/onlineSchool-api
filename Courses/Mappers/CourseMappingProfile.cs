using AutoMapper;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Models;
using online_school_api.Students.Dtos;

namespace online_school_api.Courses.Mappers
{
    public class CourseMappingProfile:Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseRequest, Course>();
            CreateMap<Course, CourseStudentsResponse>();

            CreateMap<Course, GetAllCourseDto>()
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Enrolments.Select(e => new StudentDto
                {
                    Name = e.Student.Name,
                    Email = e.Student.Email
                }
                )));
        }
    }
}
