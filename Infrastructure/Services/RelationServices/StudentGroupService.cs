using System.Net;
using AutoMapper;
using Domain.DTOs.StudentGroupDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.RelationServices;

public class StudentGroupService(DataContext context, IMapper mapper) : IStudentGroupService
{
    public async Task<Response<string>> AddStudentGroupAsync(AddStudentGroupDto add)
    {
        try
        {
            
        var mapped = mapper.Map<StudentGroup>(add);
        await context.StudentGroups.AddAsync(mapped);
        await context.SaveChangesAsync();
            if(mapped != null)return new Response<string>("Added Successfully!");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add !");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetStudentGroupDto>>> GetStudentGroupAsync()
    {
        try
        {
            var result = await context.StudentGroups.ToListAsync();
            if(result != null) return new Response<List<GetStudentGroupDto>>(mapper.Map<List<GetStudentGroupDto>>(result));
            
            return new Response<List<GetStudentGroupDto>>(HttpStatusCode.BadRequest,"Error");

        }
        catch (System.Exception e)
        {
            return new Response<List<GetStudentGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetStudentGroupDto>> GetStudentGroupByIdAsync(int id)
    {
        try
        {
            var result = await context.StudentGroups.FindAsync(id);
            if (result == null)
            {
                return new Response<GetStudentGroupDto>(HttpStatusCode.BadRequest,"Not Found!");
            }else
            {
                return new Response<GetStudentGroupDto>(mapper.Map<GetStudentGroupDto>(result));
            }
        }
        catch (System.Exception e)
        {
            return new Response<GetStudentGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateStudentGroupAsync(UpdateStudentGroupDto update)
    {
        try
        {
            var result = await context.StudentGroups.FindAsync(update.Id);
            if (result == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");

            mapper.Map(update,result);
            await context.SaveChangesAsync();
            return new Response<string>("Yet Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

        public async Task<Response<bool>> DeleteStudentGroupAsync(int id)
    {
        try
        {
            var result = await context.StudentGroups.FindAsync(id);
            if (result == null)
            {
                return new Response<bool>(HttpStatusCode.BadRequest,"Not Found ",false);
            }
            context.StudentGroups.Remove(result);
            await context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.Accepted,"Deleted",true);
        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
