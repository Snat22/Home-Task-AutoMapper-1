using Domain.DTOs.CourseDtos;
using Domain.Responses;

namespace Infrastructure.Services.CourseServices;

public interface ICourseService
{
    Task<Response<List<GetCourseDto>>> GetCourseAsync();
    Task<Response<GetCourseDto>> GetCourseByIdAsync(int id);
    Task<Response<string>> AddCourseAsync(AddCourseDto add);
    Task<Response<string>> UpdateCourseAsync(UpdateCourseDto update);
    Task<Response<bool>> DeleteCourseAsync(int id);
}
