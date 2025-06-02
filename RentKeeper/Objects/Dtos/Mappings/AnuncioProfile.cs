using AutoMapper;
using RentKeeper.Objects.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Objects.Mappings
{
    public class AnuncioProfile : Profile
    {
        public AnuncioProfile()
        {
			CreateMap<AnuncioCreateDto, Anuncio>()
	.ForMember(dest => dest.DataPartida, opt =>
		opt.MapFrom(src => DateTime.SpecifyKind(src.DataPartida, DateTimeKind.Utc)))
	.ForMember(dest => dest.HoraPartida, opt =>
		opt.MapFrom(src => DateTime.SpecifyKind(src.HoraPartida, DateTimeKind.Utc)));
			CreateMap<Anuncio, AnuncioReadDto>();
		}
    }
}
