using Domain.DTOs.CourseDtos;
using Domain.Responses;
using Infrastructure.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Course")]
[ApiController]
public class CourseController(ICourseService service):ControllerBase
{
    [HttpGet("Get-Courses")]
    public async Task<Response<List<GetCourseDto>>> GetCourseList()
    {
        return await service.GetCourseAsync();
    }

    [HttpGet("courseId:int")]
    public async Task<Response<GetCourseDto>> GetCourseById(int courseId)
    {
        return await service.GetCourseByIdAsync(courseId);
    }

    [HttpPost("Add-Course")]
    public async Task<Response<string>> AddCourse(AddCourseDto add)
    {
        return await service.AddCourseAsync(add);
    }
    [HttpPut("Update-Course")]
    public async Task<Response<string>> UpdateCourse(UpdateCourseDto update)
    {
        return await service.UpdateCourseAsync(update);
    }

    [HttpDelete("courseId:int")]
    public async Task<Response<bool>> DeleteCourse(int courseId)
    {
        return await service.DeleteCourseAsync(courseId);
    }
}
