

using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface ICityRepository: IEntityRepository<App.DAL.DTO.City>
{
    Task<App.DAL.DTO.City> GetCityByNameAndCountry(string cityName, string countryAlpha2Code);
    
    Task<IEnumerable<App.DAL.DTO.City>> GetCityByCountry(string countryAlpha2Code);
}