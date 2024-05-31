using AutoMapper;

namespace App.DAL.EF;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<App.Domain.City, App.DAL.DTO.City>().ReverseMap();
        CreateMap<App.Domain.Country, App.DAL.DTO.Country>().ReverseMap();
    }
    
}