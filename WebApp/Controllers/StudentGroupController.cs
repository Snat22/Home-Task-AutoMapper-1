using Domain.DTOs.StudentGroupDtos;
using Domain.Responses;
using Infrastructure.Services.RelationServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/StudentGroup")]
[ApiController]
public class StudentGroupController(IStudentGroupService service):ControllerBase
{
    
    [HttpGet("Get-StudentGroup")]
    public async Task<Response<List<GetStudentGroupDto>>> GetStudentGroup()
    {
        return await service.GetStudentGroupAsync();
    }
    [HttpGet("studentGroup:int")]
    public async Task<Response<GetStudentGroupDto>> GetStudentGroupById(int studentGroup)
    {
        return await service.GetStudentGroupByIdAsync(studentGroup);
    }

    [HttpPost("Add-StudentGroup")]
    public async Task<Response<string>> AddStudentGroup(AddStudentGroupDto add)
    {
        return await service.AddStudentGroupAsync(add);
    }

    [HttpPut("Update-StudentGroup")]
    public async Task<Response<string>> UpdateStudentGroup(UpdateStudentGroupDto update)
    {
        return await service.UpdateStudentGroupAsync(update);
    }
    [HttpDelete("studentGrouopId:int")]
    public async Task<Response<bool>> DeleteStudentGroup(int studentGrouopId)
    {
        return await service.DeleteStudentGroupAsync(studentGrouopId);
    }
}
