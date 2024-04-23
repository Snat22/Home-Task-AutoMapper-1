using Domain.DTOs.MentorGroupDtos;
using Domain.Responses;

namespace Infrastructure.Services.RelationServices;

public interface IMentorGroupService
{
    Task<Response<List<GetMentorGroupDto>>> GetMentorGroupsAsync();
    Task<Response<GetMentorGroupDto>> GetMentorGroupByIdAsync(int id);
    Task<Response<string>> AddMentorGroupAsync(AddMentorGroupDto add);
    Task<Response<string>> UpdateMentorGroupAsync(UpdateMentorGroupDto update);
    Task<Response<bool>> DeleteMentorGroupAsync(int id);
}
