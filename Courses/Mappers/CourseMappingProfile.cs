using AutoMapper;
using online_school_api.Courses.Dtos;
using online_school_api.Courses.Models;

namespace online_school_api.Courses.Mappers
{
    public class CourseMappingProfile:Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseRequest, Course>();
            CreateMap<Course, CourseResponse>();

        }
    }
}
