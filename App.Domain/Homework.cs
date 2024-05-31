using Base.Contracts.Domain;
using Base.Domain;

namespace App.Domain;

public class Homework: BaseEntityId
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime DueDate { get; set; } = default!;
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public ICollection<UserSubjectHomework>? UserSubjectHomeworks { get; set; }
}
