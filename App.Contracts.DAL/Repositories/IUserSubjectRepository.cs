

using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface IUserSubjectRepository: IEntityRepository<App.DAL.DTO.UserSubject>, IStudentDataRepositoryCustom
{
   
}

public interface IStudentDataRepositoryCustom
{
    Task<App.DTO.v1_0.StudentData> GetStudentData(Guid id);
}