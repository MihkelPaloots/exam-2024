using App.Contracts.DAL.Repositories;
using App.Domain;
using AutoMapper;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class SubjectRepository: BaseEntityRepository<App.Domain.Subject, App.DAL.DTO.Subject, AppDbContext>, ISubjectRepository
{
    public SubjectRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new DalDomainMapper<App.Domain.Subject, App.DAL.DTO.Subject>(mapper))
    {
    }
    
}
