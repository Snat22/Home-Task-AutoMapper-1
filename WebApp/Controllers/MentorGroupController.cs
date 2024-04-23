using Domain.DTOs.MentorGroupDtos;
using Domain.Responses;
using Infrastructure.Services.RelationServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Mentor")]
[ApiController]
public class MentorGroupController(IMentorGroupService service):ControllerBase
{


    [HttpGet("Get-MentorGroups")]
    public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroups()
    {
        return await service.GetMentorGroupsAsync();
    }
    [HttpGet("mentorGroupId:int")]
    public async Task<Response<GetMentorGroupDto>> GetMentorGroupById(int mentorGroupId)
    {
        return await service.GetMentorGroupByIdAsync(mentorGroupId);
    }

    [HttpPost("Add-MentorGroup")]
    public async Task<Response<string>> AddMentorGroup(AddMentorGroupDto add)
    {
        return await service.AddMentorGroupAsync(add);
    }

    [HttpPut("Update-MentorGroup")]
    public async Task<Response<string>> UpdateMentorGroup(UpdateMentorGroupDto update)
    {
        return await service.UpdateMentorGroupAsync(update);
    }
    [HttpDelete("mentorGroupId:int")]
    public async Task<Response<bool>> DeleteMentorGroup(int mentorGroupId)
    {
        return await service.DeleteMentorGroupAsync(mentorGroupId);
    }
}
