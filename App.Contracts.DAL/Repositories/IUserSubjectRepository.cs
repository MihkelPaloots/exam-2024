

using App.DTO.v1_0;
using App.DTO.v1_0.Identity;
using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface IUserSubjectRepository: IEntityRepository<App.DAL.DTO.UserSubject>, IStudentDataRepositoryCustom
{
    Task EnrollStudents(EnrollStudentsBody enrollStudents);
}

public interface IStudentDataRepositoryCustom
{
    Task<App.DTO.v1_0.StudentData> GetStudentData(Guid id);
    Task<IEnumerable<App.DTO.v1_0.Subject>> GetSubjectsWithStudents(Guid userId);
}