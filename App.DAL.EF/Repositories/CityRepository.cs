using App.Contracts.DAL.Repositories;
using App.Domain;
using AutoMapper;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class CityRepository: BaseEntityRepository<App.Domain.City, App.DAL.DTO.City, AppDbContext>, ICityRepository
{
    public CityRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new DalDomainMapper<App.Domain.City, App.DAL.DTO.City>(mapper))
    {
    }

    public async Task<App.DAL.DTO.City> GetCityByNameAndCountry(string cityName, string countryAlpha2Code)
    {
        var query = CreateQuery();
        var result = query
            .Where(e => e.CityName.ToUpper() == cityName.ToUpper() && e.Country.CountryAlpha2Code.ToUpper() == countryAlpha2Code.ToUpper())
            .FirstOrDefaultAsync();


        return Mapper.Map( await result);
    }

    public async Task<IEnumerable<App.DAL.DTO.City>> GetCityByCountry(string countryAlpha2Code)
    {
        var query = CreateQuery();
        var result = query
            .Where(e => e.Country.CountryAlpha2Code.ToUpper() == countryAlpha2Code.ToUpper());


        return (await result.ToListAsync()).Select(e => Mapper.Map(e));
    }
}
