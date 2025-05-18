using AutoMapper;
using RentKeeper.Objects.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Objects.Mappings
{
    public class AnuncioProfile : Profile
    {
        public AnuncioProfile()
        {
            CreateMap<AnuncioCreateDto, Anuncio>();
            CreateMap<Anuncio, AnuncioReadDto>();
        }
    }
}
