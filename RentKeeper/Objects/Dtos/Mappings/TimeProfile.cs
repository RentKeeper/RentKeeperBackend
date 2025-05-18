using AutoMapper;
using RentKeeper.Objects.Models;
using RentKeeper.Objects.Dtos.Entities;
using System.Linq;

namespace RentKeeper.Objects.Mappings
{
    public class TimeProfile : Profile
    {
        public TimeProfile()
        {
            CreateMap<TimeCreateDto, Time>();
            CreateMap<Time, TimeReadDto>()
                .ForMember(dest => dest.UsuarioIds,
                           opt => opt.MapFrom(src => src.Usuarios.Select(u => u.Id)));
        }
    }
}
