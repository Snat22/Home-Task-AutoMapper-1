using Domain.Enums;
using Domain.Models;

namespace Domain.DTOs.CourseDtos;

public class GetCourseDto
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public List<Group>? Groups { get; set; }
}
