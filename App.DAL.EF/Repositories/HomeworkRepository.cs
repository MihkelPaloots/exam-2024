using App.Contracts.DAL.Repositories;
using AutoMapper;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class HomeworkRepository : BaseEntityRepository<App.Domain.Homework, App.DAL.DTO.Homework, AppDbContext>,
    IHomeworkRepository
{
    public HomeworkRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new DalDomainMapper<App.Domain.Homework, App.DAL.DTO.Homework>(mapper))
    {
    }

}