namespace App.DTO.v1_0.Identity;

public class EnrollStudentsBody
{
    public Guid subjectId { get; set; } = default!;
    public List<Guid> studentIds { get; set; } = default!;
    
}