using Domain.DTOs.StudentDtos;
using Domain.Responses;

namespace Infrastructure.Services.StudentServices;

public interface IStudentService
{
    Task<Response<List<GetStudentDto>>> GetStudentsAsync();
    Task<Response<GetStudentDto>> GetStudentByIdAsync(int id);
    Task<Response<string>> AddStudentAsync(AddStudentDto add);
    Task<Response<string>> UpdateStudentAsync(UpdateStudentDto update);
    Task<Response<bool>> DeleteStudentAsync(int id);
}
