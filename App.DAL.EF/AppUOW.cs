using App.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using App.DAL.EF.Repositories;
using App.Domain.Identity;
using AutoMapper;
using Base.Contracts.DAL;
using Base.DAL.EF;

namespace App.DAL.EF;

public class AppUOW : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
{
    private readonly IMapper _mapper;
    public AppUOW(AppDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }
    

    private IEntityRepository<AppUser>? _users;
    private ICityRepository? _cities;
    private ICountryRepository? _countries;
    private IRoleRepository? _roles;
    private ISubjectRepository? _subjects;
    private IHomeworkRepository? _homeworks;
    private IUserSubjectHomeworkRepository? _userSubjectHomeworks;
    private IUserSubjectRepository? _userSubjects;
    
    
    public ICityRepository Cities => _cities ?? new CityRepository(UowDbContext, _mapper);
    public ICountryRepository Countries => _countries ?? new CountryRepository(UowDbContext, _mapper);
    public IEntityRepository<AppUser> Users => _users ??
                                               new BaseEntityRepository<AppUser, AppUser, AppDbContext>(UowDbContext,
                                                   new DalDomainMapper<App.Domain.Identity.AppUser, AppUser>(_mapper));
    public IHomeworkRepository Homeworks => _homeworks ?? new HomeworkRepository(UowDbContext, _mapper);
    public IRoleRepository Roles => _roles ?? new RoleRepository(UowDbContext, _mapper);
    public IUserSubjectHomeworkRepository UserSubjectHomeworks => _userSubjectHomeworks ?? new UserSubjectHomeworkRepository(UowDbContext, _mapper);
    public IUserSubjectRepository UserSubjects => _userSubjects ?? new UserSubjectRepository(UowDbContext, _mapper);
    public ISubjectRepository Subjects => _subjects ?? new SubjectRepository(UowDbContext, _mapper);
}