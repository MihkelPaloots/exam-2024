

using App.DTO.v1_0;
using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface ISubjectRepository: IEntityRepository<App.DAL.DTO.Subject>, ISubjectCustom
{

}

public interface ISubjectCustom
{
    Task<IEnumerable<Subject>> GetAvailableSubjects(string? id);
}