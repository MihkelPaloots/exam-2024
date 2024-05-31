using App.Contracts.DAL.Repositories;
using App.Domain;
using App.DTO.v1_0;
using AutoMapper;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.DTO.v1_0.Identity;
using Subject = App.DTO.v1_0.Subject;

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
                    e.Enrolled,
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
                Status = e.Enrolled.HasValue && e.Enrolled.Value ? "Enrolled" : "Not enrolled - waiting for teacher approval",
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

        public async Task<IEnumerable<Subject>> GetSubjectsWithStudents(Guid userId)
        {
            var query = CreateQuery();
            var result = query
                .Where(e => e.AppUserId == userId && e.Role.RoleName == "Teacher")
                .Select(e => new App.DTO.v1_0.Subject()
                {
                    Id = e.SubjectId,
                    Name = e.Subject.Name,
                    Code = e.Subject.Code,
                    AcademicPoints = e.Subject.AcademicPoints,
                    Teacher = e.Subject.UserSubjects
                        .Where(subject => subject.Role.RoleName == "Teacher")
                        .Select(subject => subject.AppUser)
                        .FirstOrDefault() != null
                        ? $"{e.Subject.UserSubjects.Where(subject => subject.Role.RoleName == "Teacher").Select(subject => subject.AppUser).FirstOrDefault().FirstName} {e.Subject.UserSubjects.Where(subject => subject.Role.RoleName == "Teacher").Select(subject => subject.AppUser).FirstOrDefault().LastName}"
                        : string.Empty,
                    Mark = e.Mark,
                    Homeworks = e.Subject.Homeworks.Select(homework => new App.DTO.v1_0.Homework()
                    {
                        Title = homework.Title,
                        Description = homework.Description,
                        DueDate = homework.DueDate
                    }).ToList(),
                    EnrolledStudents = e.Subject.UserSubjects
                        .Where(subject => subject.Role.RoleName == "Student" && subject.Enrolled == true)
                        .Select(subject => subject.AppUser)
                        .Select(student => new Student()
                        {
                            Id = student.Id,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Email = student.Email
                        }).ToList(),
                    WaitingListStudents = e.Subject.UserSubjects
                        .Where(subject => subject.Role.RoleName == "Student" && subject.Enrolled == false)
                        .Select(subject => subject.AppUser)
                        .Select(student => new Student()
                        {
                            Id = student.Id,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Email = student.Email
                        }).ToList(),
                });

            return await result.ToListAsync();
        }
        
        public async Task EnrollStudents(EnrollStudentsBody enrollStudents)
        {
            var subjectId = enrollStudents.subjectId;
            var studentIds = enrollStudents.studentIds;

            var query = CreateQuery().Where(subject => subject. SubjectId == subjectId && studentIds.Contains(subject.AppUserId))
                .ExecuteUpdateAsync(subject => subject.SetProperty(s => s.Enrolled, true));
            
            await query;
        }
       
    }
}
