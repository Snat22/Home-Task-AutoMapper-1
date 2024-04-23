using System.Net;
using AutoMapper;
using Domain.DTOs.GroupDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.GroupServices;

public class GroupService(DataContext context, IMapper mapper) : IGroupService
{
    public async Task<Response<string>> AddGroupAsync(AddGroupDto add)
    {
        try
        {
            var mapped = mapper.Map<Group>(add);
            await context.Groups.AddAsync(mapped);

            await context.SaveChangesAsync();
            if(mapped != null) return new Response<string>("Added Succesfully!");

            return new Response<string>(HttpStatusCode.BadRequest,"Failed to add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    

    public async Task<Response<GetGroupDto>> GetGroupByIdAsync(int id)
    {
    try
    {
        var result = await context.Groups.FindAsync(id);
        if(result == null)
        {
            return new Response<GetGroupDto>(HttpStatusCode.BadRequest,"Not Found!");
        }else
        {
            return new Response<GetGroupDto>(mapper.Map<GetGroupDto>(result));
        }

    }
    catch (System.Exception e)
    {
        return new Response<GetGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        } 
    }

    public async Task<Response<List<GetGroupDto>>> GetGroupsAsync()
    {
        try
        {
            var result = await context.Groups.ToListAsync();
            if(result != null)
            {
                return new Response<List<GetGroupDto>>(mapper.Map<List<GetGroupDto>>(result));
            } 

            return new Response<List<GetGroupDto>>(HttpStatusCode.BadRequest,"Error!");
        }
        catch (System.Exception e)
        {
            return new Response<List<GetGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDto update)
    {
        try
        {
            var result = await context.Groups.FindAsync(update.Id);
            if(result == null)
            {
                return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");
            }

            mapper.Map(update,result);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Yet Updated!");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {
        try
        {
            var result = await context.Groups.FindAsync(id);
            if(result == null)
            {
                return new Response<bool>(HttpStatusCode.NotFound,"Error");
            }
            context.Groups.Remove(result);
            await context.SaveChangesAsync();
            return new Response<bool>( HttpStatusCode.OK,"Deleted");

        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
