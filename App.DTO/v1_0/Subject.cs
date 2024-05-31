namespace App.DTO.v1_0;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int AcademicPoints { get; set; }
    
    public string Teacher { get; set; } = default!;
    public string? Mark { get; set; } = default!;
    public List<Homework>? Homeworks { get; set; }
    public List<Student>? EnrolledStudents { get; set; }
    public List<Student>? WaitingListStudents { get; set; }
    public string? Status { get; set; }
}