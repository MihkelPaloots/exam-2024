using App.Contracts.DAL.Repositories;
using App.Domain;
using AutoMapper;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class CountryRepository: BaseEntityRepository<App.Domain.Country, App.DAL.DTO.Country, AppDbContext>,  ICountryRepository
{
    public CountryRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new DalDomainMapper<App.Domain.Country, App.DAL.DTO.Country>(mapper))
    {
    }
}
