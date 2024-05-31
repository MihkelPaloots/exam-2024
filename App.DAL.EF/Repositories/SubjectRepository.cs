using App.Contracts.DAL.Repositories;
using App.Domain;
using AutoMapper;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Subject = App.DTO.v1_0.Subject;

namespace App.DAL.EF.Repositories;

public class SubjectRepository: BaseEntityRepository<App.Domain.Subject, App.DAL.DTO.Subject, AppDbContext>, ISubjectRepository
{
    public SubjectRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new DalDomainMapper<App.Domain.Subject, App.DAL.DTO.Subject>(mapper))
    {
    }

    public async Task<IEnumerable<Subject>> GetAvailableSubjects(string? userId)
    {
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        var userGuid = Guid.Parse(userId);
        var query = CreateQuery();
        var subjects = await query
            .Where(s => !s.UserSubjects.Any(us => us.AppUserId == userGuid))
            .Select(s => new Subject
            {
                Id = s.Id,
                Name = s.Name,
                Code = s.Code,
                AcademicPoints = s.AcademicPoints,
                Teacher = s.UserSubjects
                    .Where(subject => subject.Role.RoleName == "Teacher")
                    .Select(subject => subject.AppUser)
                    .FirstOrDefault().LastName,
            })
            .ToListAsync();
        
        return subjects;
    }

}
