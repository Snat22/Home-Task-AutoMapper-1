using Domain.DTOs.MentorDtos;
using Domain.Responses;
using Infrastructure.Services.MentorServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Mentor")]
[ApiController]
public class MenorController(IMentorService service):ControllerBase
{
    [HttpGet("Get-Mentors")]
    public async Task<Response<List<GetMentorDto>>> GetMentors()
    {
        return await service.GetMentorsAsync();
    }
    [HttpGet("mentorId:int")]
    public async Task<Response<GetMentorDto>> GetMentorById(int mentorId)
    {
        return await service.GetMentorByIdAsync(mentorId);
    }

    [HttpPost("Add-Mentor")]
    public async Task<Response<string>> AddMentor(AddMentorDto add)
    {
        return await service.AddMentorAsync(add);
    }

    [HttpPut("Update-Mentor")]
    public async Task<Response<string>> UpdateMentor(UpdateMentorDto update)
    {
        return await service.UpdateMentorAsync(update);
    }
    [HttpDelete("mentorId:int")]
    public async Task<Response<bool>> DeleteMentor(int mentorId)
    {
        return await service.DeleteMentorASync(mentorId);
    }
}
