

using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface IRoleRepository: IEntityRepository<App.DAL.DTO.Role>, IRoleCustom
{
}

public interface IRoleCustom
{
     Task<App.DAL.DTO.Role> GetRoleByName(string student);
}