using System.Net;
using AutoMapper;
using Domain.DTOs.StudentDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentServices;

public class StudentService(DataContext context, IMapper mapper) : IStudentService
{
    public async Task<Response<string>> AddStudentAsync(AddStudentDto add)
    {
        try
        {
        var mapped = mapper.Map<Student>(add);
        await context.Students.AddAsync(mapped);
        await context.SaveChangesAsync();
        if(mapped != null)return new Response<string>("Added Successfully!");
        return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add !"); 
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }

    }

    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        try
        {
            var result = await context.Students.FindAsync(id);
            if(result == null) return new Response<GetStudentDto>(HttpStatusCode.BadRequest,"Not Found!");

            return new Response<GetStudentDto>(mapper.Map<GetStudentDto>(result));
            }
        catch (System.Exception e)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()
    {
        try
        {
            var result = await context.Students.ToListAsync();
            if(result != null) return new Response<List<GetStudentDto>>(mapper.Map<List<GetStudentDto>>(result));

            return new Response<List<GetStudentDto>>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto update)
    {
        try
        {
            var result = await context.Students.FindAsync(update.Id);
            if(result == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found");

            mapper.Map(update,result);
            await context.SaveChangesAsync();
            return new Response<string>("Yet Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    
    public async Task<Response<bool>> DeleteStudentAsync(int id)
    {
        try
        {
            var result = await context.Students.FindAsync(id);
            if(result == null) return new Response<bool>(HttpStatusCode.BadRequest,"Not Found!");

            context.Students.Remove(result);
            await context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
}
