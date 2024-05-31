using App.Contracts.DAL.Repositories;
using App.DAL.DTO;
using AutoMapper;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class RoleRepository: BaseEntityRepository<App.Domain.Role, App.DAL.DTO.Role, AppDbContext>, IRoleRepository
{
    public RoleRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new DalDomainMapper<App.Domain.Role, App.DAL.DTO.Role>(mapper))
    {
    }


    public async Task<App.DAL.DTO.Role> GetRoleByName(string roleName)
    {
        var query = CreateQuery();
        return Mapper.Map(await query
            .Where(e => e.RoleName == "Student")
            .FirstOrDefaultAsync());
    }
}