using AutoMapper;
using ImpressaoApi.DTOs;
using ImpressaoApi.Models;


namespace ImpressaoApi.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<ImpressaoLog, ImpressaoLogDto>().ReverseMap();
    }
}
