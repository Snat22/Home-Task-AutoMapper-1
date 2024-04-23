using Domain.Models;

namespace Domain.DTOs.StudentGroupDtos;

public class AddStudentGroupDto
{
    
    public int StudentId { get; set; }  
    public Student? Student { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}
