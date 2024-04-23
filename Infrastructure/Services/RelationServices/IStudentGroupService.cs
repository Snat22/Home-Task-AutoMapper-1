using Domain.DTOs.StudentGroupDtos;
using Domain.Responses;

namespace Infrastructure.Services.RelationServices;

public interface IStudentGroupService
{
    Task<Response<List<GetStudentGroupDto>>> GetStudentGroupAsync();
    Task<Response<GetStudentGroupDto>> GetStudentGroupByIdAsync(int id);
    Task<Response<string>> AddStudentGroupAsync(AddStudentGroupDto add);
    Task<Response<string>> UpdateStudentGroupAsync(UpdateStudentGroupDto update);
    Task<Response<bool>> DeleteStudentGroupAsync(int id);
}
