using Base.Domain;

namespace App.Domain;

public class Role: BaseEntityId
{
    public String RoleName { get; set; } = default!;
    public ICollection<UserSubject>? UserSubjects { get; set; }
}