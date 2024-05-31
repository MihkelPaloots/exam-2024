using Base.Domain;

namespace App.Domain;

public class Subject: BaseEntityId
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int AcademicPoints { get; set; }
    public ICollection<UserSubject>? UserSubjects { get; set; }
    public ICollection<Homework>? Homeworks { get; set; }
    
}