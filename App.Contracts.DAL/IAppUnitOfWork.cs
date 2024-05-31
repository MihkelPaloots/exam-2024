using App.Contracts.DAL.Repositories;
using App.Domain.Identity;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IAppUnitOfWork : IUnitOfWork
{
    
    ICityRepository Cities { get; }
    ICountryRepository Countries { get; }
    IEntityRepository<AppUser> Users { get; } 
    IHomeworkRepository Homeworks { get; }
    IRoleRepository Roles { get; }
    IUserSubjectHomeworkRepository UserSubjectHomeworks { get; }
    IUserSubjectRepository UserSubjects { get; }
    ISubjectRepository Subjects { get; }
}