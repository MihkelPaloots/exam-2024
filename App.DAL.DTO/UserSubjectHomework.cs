using Base.Domain;

namespace App.DAL.DTO;

public class UserSubjectHomework: BaseEntityId
{
    public Guid UserSubjectId { get; set; }
    public UserSubject? UserSubject { get; set; }
    public Guid HomeworkId { get; set; }
    public Homework? Homework { get; set; }
    public int Mark { get; set; }
}