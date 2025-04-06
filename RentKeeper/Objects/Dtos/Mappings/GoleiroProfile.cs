using AutoMapper;
using RentKeeper.Models;
using RentKeeper.Objects.Dtos.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Goleiro, GoleiroDto>().ReverseMap();
        // Pode adicionar outros mappings aqui também
    }
}
