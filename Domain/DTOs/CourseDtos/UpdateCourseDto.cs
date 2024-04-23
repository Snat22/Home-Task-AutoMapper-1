using Domain.Enums;
using Domain.Models;

namespace Domain.DTOs.CourseDtos;

public class UpdateCourseDto
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public List<Group>? Groups { get; set; }
    public Gender Gender { get; set; }
}
