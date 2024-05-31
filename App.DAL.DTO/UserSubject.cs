using App.Domain.Identity;
using Base.Contracts.Domain;
using Base.Domain;

namespace App.DAL.DTO;

public class UserSubject: BaseEntityId, IDomainAppUser<AppUser>
{
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public ICollection<UserSubjectHomework>? UserSubjectHomeworks { get; set; }
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
    
    public string? Mark { get; set; }
    public bool? Enrolled { get; set; }
}
