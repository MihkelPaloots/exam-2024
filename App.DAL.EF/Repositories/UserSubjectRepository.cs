using App.Contracts.DAL.Repositories;
using App.Domain;
using App.DTO.v1_0;
using AutoMapper;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.EF.Repositories
{
    public class UserSubjectRepository : BaseEntityRepository<App.Domain.UserSubject, App.DAL.DTO.UserSubject, AppDbContext>, IUserSubjectRepository
    {
        public UserSubjectRepository(AppDbContext dbContext, IMapper mapper) :
            base(dbContext, new DalDomainMapper<App.Domain.UserSubject, App.DAL.DTO.UserSubject>(mapper))
        {
        }

        public async Task<StudentData> GetStudentData(Guid id)
        {
            var query = CreateQuery();
            var subjectsQ = query
                .Where(e => e.AppUserId == id)
                .Select(e => new
                {
                    e.SubjectId,
                    e.Subject.AcademicPoints,
                    e.Mark,
                    e.Subject.Name,
                    e.Subject.Code,
                    Teacher = e.Subject.UserSubjects
                        .Where(subject => subject.Role.RoleName == "Teacher")
                        .Select(subject => subject.AppUser)
                        .FirstOrDefault()
                });

            var subjectsList = await subjectsQ.ToListAsync();

            var subjects = subjectsList.Select(e => new App.DTO.v1_0.Subject()
            {
                Id = e.SubjectId,
                AcademicPoints = e.AcademicPoints,
                Mark = e.Mark,
                Name = e.Name,
                Code = e.Code,
                Teacher = e.Teacher != null ? $"{e.Teacher.FirstName} {e.Teacher.LastName}" : string.Empty,
            }).ToList();

            var result = new App.DTO.v1_0.StudentData()
            {
                subjects = subjects,
                totalAcademicPoints = subjects
                    .Where(subject => subject.Mark is not (null or "0" or "MA"))
                    .Sum(subject => subject.AcademicPoints),
                averageMark = subjects
                    .Where(subject => subject.Mark is not (null or "0" or "MA"))
                    .Average(subject => subject.Mark != null ? double.Parse(subject.Mark) : 0)
            };

            return result;
        }
    }
}
