using AutoMapper;

namespace WebApp.Util;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<App.DAL.DTO.City, App.DTO.v1_0.City>().ReverseMap();
        CreateMap<App.DAL.DTO.Country, App.DTO.v1_0.Country>().ReverseMap();

    }
}