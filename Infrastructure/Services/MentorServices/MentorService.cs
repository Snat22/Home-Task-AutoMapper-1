using System.Net;
using AutoMapper;
using Domain.DTOs.MentorDtos;
using Domain.Models;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MentorServices;

public class MentorService(DataContext context, IMapper mapper) : IMentorService
{
    public async Task<Response<string>> AddMentorAsync(AddMentorDto add)
    {
        try
        {
            var mapped = mapper.Map<Mentor>(add);
            await context.Mentors.AddAsync(mapped);
            await context.SaveChangesAsync();
            if(mapped != null) return new Response<string>("Added Success");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed To Add");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<GetMentorDto>> GetMentorByIdAsync(int id)
    {
        try
        {
            
        var result = await context.Mentors.FindAsync(id);
        if(result == null) return new Response<GetMentorDto>(HttpStatusCode.BadRequest,"Not Found!");

        return new Response<GetMentorDto>(mapper.Map<GetMentorDto>(result));
        }
        catch (System.Exception e)
        {
            return new Response<GetMentorDto>(HttpStatusCode.InternalServerError,e.Message);
        }

    }

    public async Task<Response<List<GetMentorDto>>> GetMentorsAsync()
    {
        try
        {
            var result = await context.Mentors.ToListAsync();
            if(result == null) return new Response<List<GetMentorDto>>(HttpStatusCode.BadRequest,"Error");

            return new Response<List<GetMentorDto>>(mapper.Map<List<GetMentorDto>>(result));
        }

        catch (System.Exception e)
        {
            return new Response<List<GetMentorDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateMentorAsync(UpdateMentorDto update)
    {
        try
        {
            var result = await context.Mentors.FindAsync(update.Id);
            if(result == null) return new Response<string>(HttpStatusCode.BadRequest,"Not Found!");
            
            mapper.Map(update,result);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.Accepted,"Yet Updated");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    
    public Task<Response<bool>> DeleteMentorASync(int id)
    {
        throw new NotImplementedException();
    }
}
