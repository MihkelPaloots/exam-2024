using App.Contracts.DAL.Repositories;
using App.Domain;
using AutoMapper;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Subject = App.DTO.v1_0.Subject;

namespace App.DAL.EF.Repositories;

public class UserSubjectHomeworkRepository: BaseEntityRepository<App.Domain.UserSubjectHomework, App.DAL.DTO.UserSubjectHomework, AppDbContext>, IUserSubjectHomeworkRepository
{
    public UserSubjectHomeworkRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new DalDomainMapper<App.Domain.UserSubjectHomework, App.DAL.DTO.UserSubjectHomework>(mapper))
    {
    }
}
