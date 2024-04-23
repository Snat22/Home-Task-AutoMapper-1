using AutoMapper;
using Domain.DTOs.CourseDtos;
using Domain.DTOs.GroupDtos;
using Domain.DTOs.MentorDtos;
using Domain.DTOs.StudentDtos;
using Domain.Models;

namespace Infrastructure.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        //STUDENT
        CreateMap<Student,AddStudentDto>().ReverseMap();
        CreateMap<Student,GetStudentDto>().ReverseMap();
        CreateMap<Student,UpdateStudentDto>().ReverseMap();
        
        //COURSE
        CreateMap<Course,AddCourseDto>().ReverseMap();
        CreateMap<Course,GetCourseDto>().ReverseMap();
        CreateMap<Course,UpdateCourseDto>().ReverseMap();

        //MENTOR
        CreateMap<Mentor,AddMentorDto>().ReverseMap();
        CreateMap<Mentor,GetMentorDto>().ReverseMap();
        CreateMap<Mentor,UpdateMentorDto>().ReverseMap();

        //GROUP
        CreateMap<Group,AddGroupDto>().ReverseMap();
        CreateMap<Group,GetGroupDto>().ReverseMap();
        CreateMap<Group,UpdateGroupDto>().ReverseMap();
        
    }
}
