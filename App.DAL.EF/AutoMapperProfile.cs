using AutoMapper;

namespace App.DAL.EF;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<App.Domain.City, App.DAL.DTO.City>().ReverseMap();
        CreateMap<App.Domain.Country, App.DAL.DTO.Country>().ReverseMap();
        CreateMap<App.Domain.Subject, App.DAL.DTO.Subject>().ReverseMap();
        CreateMap<App.Domain.UserSubject, App.DAL.DTO.UserSubject>().ReverseMap();
        CreateMap<App.Domain.Role, App.DAL.DTO.Role>().ReverseMap();
        CreateMap<App.Domain.UserSubjectHomework, App.DAL.DTO.UserSubjectHomework>().ReverseMap();
        CreateMap<App.Domain.Homework, App.DAL.DTO.Homework>().ReverseMap();
        
    }
    
}