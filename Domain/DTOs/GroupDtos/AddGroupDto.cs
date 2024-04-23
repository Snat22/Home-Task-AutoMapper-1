using Domain.Enums;
using Domain.Models;

namespace Domain.DTOs.GroupDtos;

public class AddGroupDto
{
    
    public required string GroupName { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public int CourseID { get; set; }
    public Course? Course { get; set; }
    public List<StudentGroup>? StudentGroups { get; set; }
    public List<MentorGroup>? MentorGroups { get; set; }
    
}
