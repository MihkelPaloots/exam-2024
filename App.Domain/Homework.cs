using Base.Contracts.Domain;
using Base.Domain;

namespace App.Domain;

public class Homework: BaseEntityId
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int TotalMarks { get; set; }
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public ICollection<UserSubjectHomework>? UserSubjectHomeworks { get; set; }
}
