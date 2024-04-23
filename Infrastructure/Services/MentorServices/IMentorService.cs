using Domain.DTOs.MentorDtos;
using Domain.Responses;

namespace Infrastructure.Services.MentorServices;

public interface IMentorService
{
    Task<Response<List<GetMentorDto>>> GetMentorsAsync();
    Task<Response<GetMentorDto>> GetMentorByIdAsync(int id);
    Task<Response<string>> AddMentorAsync(AddMentorDto add);
    Task<Response<string>> UpdateMentorAsync(UpdateMentorDto update);
    Task<Response<bool>> DeleteMentorASync(int id);
}
