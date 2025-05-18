using AutoMapper;
using RentKeeper.Objects.Models;
using RentKeeper.Objects.Dtos.Entities;

namespace RentKeeper.Objects.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<Usuario, UsuarioReadDto>();
        }
    }
}