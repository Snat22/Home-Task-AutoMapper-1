using System.Net;
using AutoMapper;
using Domain.DTOs.MentorGroupDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.RelationServices;

public class MentorGroupService(DataContext context, IMapper mapper) : IMentorGroupService
{
    public async Task<Response<string>> AddMentorGroupAsync(AddMentorGroupDto add)
    {
        try
        {
        var mapped = mapper.Map<MentorGroup>(add);
        await context.AddRangeAsync(mapped);
        await context.SaveChangesAsync();
        
        if(mapped != null)return new Response<string>("Added Successfully!");
        return new Response<string>(HttpStatusCode.BadRequest,"Failed to Add !");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);            
        }
    }

    public async Task<Response<GetMentorGroupDto>> GetMentorGroupByIdAsync(int id)
    {
        try
        {
            
            var result = await context.MentorGroups.FindAsync(id);
            if(result == null) return new Response<GetMentorGroupDto>(HttpStatusCode.BadRequest,"Not found!");

            return new Response<GetMentorGroupDto>(mapper.Map<GetMentorGroupDto>(result));
        }
        catch (System.Exception e)
        {
            return new Response<GetMentorGroupDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetMentorGroupDto>>> GetMentorGroupsAsync()
    {
        try
        {
            var result = await context.MentorGroups.ToListAsync();
            if(result != null) return new Response<List<GetMentorGroupDto>>(mapper.Map<List<GetMentorGroupDto>>(result));

            return new Response<List<GetMentorGroupDto>>(HttpStatusCode.BadRequest,"Error!");
        }
        catch (System.Exception e)
        {
            return new Response<List<GetMentorGroupDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateMentorGroupAsync(UpdateMentorGroupDto update)
    {
        try
        {
            var result = await context.MentorGroups.FindAsync(update.Id);
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
        public async Task<Response<bool>> DeleteMentorGroupAsync(int id)
    {
        try
        {
            var result = await context.MentorGroups.FindAsync(id);
            if(result == null)
            {
                return new Response<bool>(HttpStatusCode.BadRequest,"Not Found ",false);
            }
            context.MentorGroups.Remove(result);
            await context.SaveChangesAsync();
                        return new Response<bool>(HttpStatusCode.Accepted,"Deleted",true);

        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
