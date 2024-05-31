using App.Contracts.DAL.Repositories;
using AutoMapper;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class RoleRepository: BaseEntityRepository<App.Domain.Role, App.DAL.DTO.Role, AppDbContext>, IRoleRepository
{
    public RoleRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new DalDomainMapper<App.Domain.Role, App.DAL.DTO.Role>(mapper))
    {
    }
    
    
}